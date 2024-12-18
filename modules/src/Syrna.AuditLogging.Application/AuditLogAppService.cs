﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Syrna.AuditLogging.Dtos;
using Syrna.AuditLogging.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AuditLogging;

namespace Syrna.AuditLogging
{
    [Authorize(AuditLoggingPermissions.AuditLogs.Default)]
    public class AuditLogAppService : ReadOnlyAppService<AuditLog, AuditLogListDto, Guid, GetAuditLogsInput>, IAuditLogAppService
    {
        private IAuditLogRepository LogRepository { get; }

        public AuditLogAppService(IAuditLogRepository logRepository) : base(logRepository)
        {
            LogRepository = logRepository;
        }

        public override async Task<PagedResultDto<AuditLogListDto>> GetListAsync(GetAuditLogsInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await LogRepository.GetQueryableAsync();
            var tempQuery = queryable
                .WhereIf(!input.Filtering.IsNullOrEmpty(), input.Filtering)
                .WhereIf(!input.HttpMethod.IsNullOrEmpty(), l => l.HttpMethod.Equals(input.HttpMethod))
                .WhereIf(!input.Url.IsNullOrEmpty(), l => l.Url.Contains(input.Url))
                .WhereIf(input.HttpStatusCode.HasValue, l => l.HttpStatusCode == input.HttpStatusCode.Value)
                .WhereIf(input.StartDate.HasValue,
                    l => l.ExecutionTime >
                         Convert.ToDateTime(input.StartDate.Value.ToString("yyyy-MM-dd") + " 00:00:00"))
                .WhereIf(input.EndDate.HasValue,
                    l => l.ExecutionTime <
                         Convert.ToDateTime(input.EndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59"))
                .OrderByIf(!input.Sorting.IsNullOrEmpty(), input.Sorting);
            var totalCount = await AsyncExecuter.LongCountAsync(tempQuery);

            var logs = await AsyncExecuter.ToListAsync(tempQuery
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            var dtos = ObjectMapper.Map<List<AuditLog>, List<AuditLogListDto>>(logs);
            return new PagedResultDto<AuditLogListDto>(totalCount, dtos);
        }

        public virtual async Task<AuditLogDetailDto> GetDetailAsync(Guid id)
        {
            var log = await LogRepository.GetAsync(id);
            return ObjectMapper.Map<AuditLog, AuditLogDetailDto>(log);
        }

        protected virtual async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(AuditLogSetings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
    }
}
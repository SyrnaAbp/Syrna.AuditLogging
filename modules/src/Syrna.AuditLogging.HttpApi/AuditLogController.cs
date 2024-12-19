using System;
using System.Threading.Tasks;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Syrna.AuditLogging.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Syrna.AuditLogging
{
    /// <summary>
    /// Log management
    /// </summary>
    [RemoteService(Name = AuditLoggingRemoteServiceConsts.RemoteServiceName)]
    [Area(AuditLoggingRemoteServiceConsts.ModuleName)]
    [ControllerName("AuditLog")]
    [Route("api/audit-logging")]
    public class AuditLogController : AuditLoggingController, IAuditLogAppService
    {
        private IAuditLogAppService AuditLogAppService { get; }

        public AuditLogController(IAuditLogAppService auditLogAppService)
        {
            AuditLogAppService = auditLogAppService;
        }

        /// <summary>
        /// Detail
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public virtual async Task<AuditLogDetailDto> GetDetailAsync(Guid id)
        {
            return await AuditLogAppService.GetDetailAsync(id);
        }

        /// <summary>
        /// Pagination
        /// </summary>
        /// <param name="input">Query parameter</param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<PagedResultDto<AuditLogListDto>> GetListAsync(GetAuditLogsInput input)
        {
            return await AuditLogAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<AuditLogListDto> GetAsync(Guid id)
        {
            return await AuditLogAppService.GetAsync(id);
        }
    }
}
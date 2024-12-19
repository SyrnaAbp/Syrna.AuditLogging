using System;
using System.Threading.Tasks;
using Syrna.AuditLogging.Dtos;
using Volo.Abp.Application.Services;

namespace Syrna.AuditLogging
{
    /// <summary>
    /// Log management
    /// </summary>
    public interface IAuditLogAppService : IReadOnlyAppService<
        AuditLogListDto,
        Guid,
        GetAuditLogsInput>
    {
        /// <summary>
        /// Detail
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns></returns>
        Task<AuditLogDetailDto> GetDetailAsync(Guid id);
    }
}
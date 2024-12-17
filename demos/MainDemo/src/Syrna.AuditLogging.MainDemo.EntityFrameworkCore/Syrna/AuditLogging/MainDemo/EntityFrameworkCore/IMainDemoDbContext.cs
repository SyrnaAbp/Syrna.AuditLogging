using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Syrna.AuditLogging;

namespace Syrna.AuditLogging.MainDemo.EntityFrameworkCore
{
    [ConnectionStringName(AuditLoggingDbProperties.ConnectionStringName)]
    public interface IMainDemoDbContext : IEfCoreDbContext
    {
    }
}

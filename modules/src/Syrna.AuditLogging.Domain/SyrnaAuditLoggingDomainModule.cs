using Volo.Abp.AuditLogging;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Syrna.AuditLogging;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(SyrnaAuditLoggingDomainSharedModule),
    typeof(AbpAuditLoggingDomainModule)
)]
public class SyrnaAuditLoggingDomainModule : AbpModule
{
}
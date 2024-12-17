using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Syrna.AuditLogging;

[DependsOn(
    typeof(SyrnaAuditLoggingDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class SyrnaAuditLoggingApplicationContractsModule : AbpModule
{
}
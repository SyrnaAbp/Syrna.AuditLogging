using Volo.Abp.Modularity;

namespace Syrna.AuditLogging
{
    [DependsOn(
        typeof(SyrnaAuditLoggingApplicationModule),
        typeof(AuditLoggingDomainTestModule)
        )]
    public class AuditLoggingApplicationTestModule : AbpModule
    {

    }
}

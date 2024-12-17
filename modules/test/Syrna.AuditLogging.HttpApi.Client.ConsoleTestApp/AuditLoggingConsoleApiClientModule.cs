using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Syrna.AuditLogging
{
    [DependsOn(
        typeof(SyrnaAuditLoggingHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class AuditLoggingConsoleApiClientModule : AbpModule
    {
        
    }
}

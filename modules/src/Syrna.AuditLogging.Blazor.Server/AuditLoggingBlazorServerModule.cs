using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Syrna.AuditLogging.Blazor.Server
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsServerThemingModule),
        typeof(AuditLoggingBlazorModule)
        )]
    public class AuditLoggingBlazorServerModule : AbpModule
    {
        
    }
}
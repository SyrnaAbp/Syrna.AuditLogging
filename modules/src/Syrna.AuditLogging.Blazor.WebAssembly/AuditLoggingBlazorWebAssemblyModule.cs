using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Syrna.AuditLogging.Blazor.WebAssembly
{
    [DependsOn(
        typeof(AuditLoggingBlazorModule),
        typeof(SyrnaAuditLoggingHttpApiClientModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
        )]
    public class AuditLoggingBlazorWebAssemblyModule : AbpModule
    {
        
    }
}
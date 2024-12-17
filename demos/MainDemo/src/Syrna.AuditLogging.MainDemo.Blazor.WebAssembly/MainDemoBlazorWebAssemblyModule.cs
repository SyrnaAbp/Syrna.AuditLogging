using Syrna.AuditLogging.MainDemo.Blazor;
using Volo.Abp.Modularity;

namespace Syrna.AuditLogging.MainDemo.Blazor.WebAssembly;

[DependsOn(
    typeof(MainDemoBlazorModule)
)]
public class MainDemoBlazorWebAssemblyModule : AbpModule
{
}

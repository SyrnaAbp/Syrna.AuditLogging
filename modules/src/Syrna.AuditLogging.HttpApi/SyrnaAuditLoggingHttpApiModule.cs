using Localization.Resources.AbpUi;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Syrna.AuditLogging.Localization;

namespace Syrna.AuditLogging;

[DependsOn(
    typeof(SyrnaAuditLoggingApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class SyrnaAuditLoggingHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SyrnaAuditLoggingHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AuditLoggingResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
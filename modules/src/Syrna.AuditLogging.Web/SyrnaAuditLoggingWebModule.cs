using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Syrna.AuditLogging.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Syrna.AuditLogging.Permissions;
using Volo.Abp.Json;
using Syrna.AuditLogging.Localization;

namespace Syrna.AuditLogging.Web;

[DependsOn(
    typeof(SyrnaAuditLoggingApplicationContractsModule),
    typeof(AbpAspNetCoreMvcUiThemeSharedModule),
    typeof(AbpAutoMapperModule)
    //typeof(SyrnaAspNetCoreMvcUiSelect2ThemeModule)
    )]
public class SyrnaAuditLoggingWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(typeof(AuditLoggingResource), typeof(SyrnaAuditLoggingWebModule).Assembly);
        });

        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SyrnaAuditLoggingWebModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpJsonOptions>(options =>
        {
            options.OutputDateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        });
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new AuditLoggingMenuContributor());
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SyrnaAuditLoggingWebModule>();
        });

        context.Services.AddAutoMapperObjectMapper<SyrnaAuditLoggingWebModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<SyrnaAuditLoggingWebModule>(validate: true);
        });

        Configure<RazorPagesOptions>(options =>
        {
            //Configure authorization.
        });
    }
}
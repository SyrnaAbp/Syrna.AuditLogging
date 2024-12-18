using Microsoft.Extensions.DependencyInjection;
using Syrna.AuditLogging.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.BlazoriseUI;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Syrna.AuditLogging.Blazor
{
    [DependsOn(
        typeof(SyrnaAuditLoggingApplicationContractsModule),
        typeof(AbpAspNetCoreComponentsWebThemingModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpBlazoriseUIModule)
        )]
    public class AuditLoggingBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AuditLoggingBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AuditLoggingBlazorAutoMapperProfile>(validate: true);
            });

            context.Services.AddAutoMapperObjectMapper<AuditLoggingBlazorModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AuditLoggingBlazorModule>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new AuditLoggingMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(AuditLoggingBlazorModule).Assembly);
            });
        }
    }
}
using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.AuditLogging;
using Syrna.AuditLogging.Localization;

namespace Syrna.AuditLogging;

[DependsOn(
    typeof(AbpValidationModule),
    typeof(AbpAuditLoggingDomainSharedModule)
)]
public class SyrnaAuditLoggingDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SyrnaAuditLoggingDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<AuditLoggingResource>("en")
                .AddBaseTypes(typeof(Volo.Abp.AuditLogging.Localization.AuditLoggingResource))
                //.AddBaseResources("AbpAuditLogging")
                //.AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("Syrna/AuditLogging/Localization/DomainShared");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("AuditLogging", typeof(AuditLoggingResource));
        });
    }
}
using Syrna.AuditLogging.MainDemo;
using Syrna.AuditLogging.MainDemo.Localization;
using Volo.Abp.Application.Services;

namespace Syrna.AuditLogging.MainDemo.SettingManagement;

public abstract class SettingManagementAppServiceBase : ApplicationService
{
    protected SettingManagementAppServiceBase()
    {
        ObjectMapperContext = typeof(MainDemoApplicationModule);
        LocalizationResource = typeof(MainDemoResource);
    }
}

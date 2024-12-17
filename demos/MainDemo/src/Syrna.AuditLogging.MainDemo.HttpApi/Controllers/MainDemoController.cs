using Syrna.AuditLogging.MainDemo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Syrna.AuditLogging.MainDemo.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MainDemoController : AbpControllerBase
{
    protected MainDemoController()
    {
        LocalizationResource = typeof(MainDemoResource);
    }
}

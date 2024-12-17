using Syrna.AuditLogging.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Syrna.AuditLogging.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class AuditLoggingPageModel : AbpPageModel
{
    protected AuditLoggingPageModel()
    {
        LocalizationResourceType = typeof(AuditLoggingResource);
        ObjectMapperContext = typeof(SyrnaAuditLoggingWebModule);
    }
}

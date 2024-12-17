using Syrna.AuditLogging.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Syrna.AuditLogging;

public abstract class AuditLoggingController : AbpControllerBase
{
    protected AuditLoggingController()
    {
        LocalizationResource = typeof(AuditLoggingResource);
    }
}

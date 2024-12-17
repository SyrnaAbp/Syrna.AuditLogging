using Syrna.AuditLogging.Localization;
using Volo.Abp.Application.Services;

namespace Syrna.AuditLogging;

public abstract class AuditLoggingAppService : ApplicationService
{
    protected AuditLoggingAppService()
    {
        LocalizationResource = typeof(AuditLoggingResource);
        ObjectMapperContext = typeof(SyrnaAuditLoggingApplicationModule);
    }
}

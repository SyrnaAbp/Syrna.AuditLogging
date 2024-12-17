using Volo.Abp.Reflection;

namespace Syrna.AuditLogging.Permissions;

public class AuditLoggingPermissions
{
    public const string GroupName = "SyrnaAuditLogging";

    public static class AuditLogs
    {
        public const string Default = GroupName + ".AuditLog";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(AuditLoggingPermissions));
    }
}
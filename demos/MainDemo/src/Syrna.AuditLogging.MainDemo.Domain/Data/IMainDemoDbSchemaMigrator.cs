using System.Threading.Tasks;

namespace Syrna.AuditLogging.MainDemo.Data;

public interface IMainDemoDbSchemaMigrator
{
    Task MigrateAsync();
}

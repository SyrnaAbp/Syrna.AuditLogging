using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Syrna.AuditLogging.AuditLogs
{
    public class AuditLogAppServiceTests : AuditLoggingApplicationTestBase
    {
        private readonly IAuditLogAppService _auditLogAppService;

        public AuditLogAppServiceTests()
        {
            _auditLogAppService = GetRequiredService<IAuditLogAppService>();
        }

        [Fact]
        public virtual async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}

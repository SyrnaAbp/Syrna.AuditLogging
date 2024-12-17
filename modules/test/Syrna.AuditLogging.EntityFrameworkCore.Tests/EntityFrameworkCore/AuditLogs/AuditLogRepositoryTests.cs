using System;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Syrna.AuditLogging.EntityFrameworkCore.AuditLogs
{
    public class AuditLogRepositoryTests : AuditLoggingEntityFrameworkCoreTestBase
    {
        private readonly IRepository<AuditLog, Guid> _privateMessageRepository;

        public AuditLogRepositoryTests()
        {
            _privateMessageRepository = GetRequiredService<IRepository<AuditLog, Guid>>();
        }

        [Fact]
        public virtual async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
    }
}

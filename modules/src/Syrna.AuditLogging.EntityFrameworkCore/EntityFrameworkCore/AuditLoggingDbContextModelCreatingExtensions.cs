using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;
using Volo.Abp.AuditLogging.EntityFrameworkCore;

namespace Syrna.AuditLogging.EntityFrameworkCore;

public static class AuditLoggingDbContextModelCreatingExtensions
{
    public static void ConfigureSyrnaAuditLogging(
        this ModelBuilder builder,
            Action<AuditLoggingModelBuilderConfigurationOptions> optionsAction = null)
    {
        Check.NotNull(builder, nameof(builder));

        var options = new AuditLoggingModelBuilderConfigurationOptions(
                AuditLoggingDbProperties.DbTablePrefix,
                AuditLoggingDbProperties.DbSchema
            );

        optionsAction?.Invoke(options);

        builder.ConfigureAuditLogging();
    }
}
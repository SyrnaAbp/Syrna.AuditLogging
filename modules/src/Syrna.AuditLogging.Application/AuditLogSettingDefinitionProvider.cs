﻿using Volo.Abp.Settings;

namespace Syrna.AuditLogging
{
    public class AuditLogSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    AuditLogSetings.MaxPageSize,
                    "100",
                    isVisibleToClients: true
                )
            );
        }
    }
}
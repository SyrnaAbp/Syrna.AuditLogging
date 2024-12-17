﻿using Syrna.AuditLogging.MainDemo.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Syrna.AuditLogging.MainDemo.Settings;

public class MainDemoSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AlphaSettings.MySetting1));

        //Gridin son filtre ayarlarını anımsa
        context.Add(new SettingDefinition(MainDemoSettings.RememberGridFilterState, "false", L("DisplayName:Syrna.AuditLogging.RememberGridFilterState"), L("Description:Syrna.AuditLogging.RememberGridFilterState")));
    }
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MainDemoResource>(name);
    }
}
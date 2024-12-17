﻿using Syrna.AuditLogging.MainDemo.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Syrna.AuditLogging.MainDemo.Blazor.Server.Host
{
    public abstract class MainDemoComponentBase : AbpComponentBase
    {
        protected MainDemoComponentBase()
        {
            LocalizationResource = typeof(MainDemoResource);
        }
    }
}

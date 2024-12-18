using System;
using System.Globalization;
using System.Threading.Tasks;
using Blazorise;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Syrna.AuditLogging.Dtos;
using Syrna.AuditLogging.Localization;
using Syrna.AuditLogging.Permissions;

namespace Syrna.AuditLogging.Blazor.Components;

public partial class DetailsModal
{
    [Inject]
    protected new IStringLocalizer<AuditLoggingResource> L { get; set; }

    [Inject]
    protected IAuditLogAppService AuditLogAppService { get; set; }

    private Modal DetailsModalRef { get; set; }

    protected AuditLogDetailDto DetailsEntity { get; set; }

    protected bool IsSystemUserMessage { get; set; }

    protected virtual Task ClosingDetailsModal(ModalClosingEventArgs eventArgs)
    {
        eventArgs.Cancel = eventArgs.CloseReason == CloseReason.FocusLostClosing;
        return Task.CompletedTask;
    }

    public DetailsModal()
    {
        LocalizationResource = typeof(AuditLoggingResource);
    }

    protected override async Task OnInitializedAsync()
    {
        DetailsEntity = new AuditLogDetailDto();

        await TrySetPermissionsAsync();
        await base.OnInitializedAsync();
    }

    private async Task TrySetPermissionsAsync()
    {
        if (IsDisposed)
        {
            return;
        }

        await SetPermissionsAsync();
    }

    protected virtual async Task SetPermissionsAsync()
    {
        if (DetailsPolicyName != null)
        {
            HasDetailsPermission = await AuthorizationService.IsGrantedAsync(DetailsPolicyName);
        }
    }

    protected bool HasDetailsPermission { get; set; }
    private string DetailsPolicyName = AuditLoggingPermissions.AuditLogs.Default;
    public virtual async Task OpenDetailsModalAsync(Guid id)
    {
        try
        {
            await CheckDetailsPolicyAsync();

            DetailsEntity = await AuditLogAppService.GetDetailAsync(id);

            await InvokeAsync(async () =>
            {
                StateHasChanged();
                if (DetailsModalRef != null)
                {
                    await DetailsModalRef.Show();
                }
            });
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    protected virtual async Task CheckDetailsPolicyAsync()
    {
        await CheckPolicyAsync(DetailsPolicyName).ConfigureAwait(false);
    }

    protected virtual async Task CheckPolicyAsync(string policyName)
    {
        if (string.IsNullOrEmpty(policyName))
        {
            return;
        }

        await AuthorizationService.CheckAsync(policyName).ConfigureAwait(false);
    }

    protected virtual Task CloseDetailsModalAsync()
    {
        return InvokeAsync(new Func<Task>(DetailsModalRef.Hide));
    }


    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            DetailsModalRef?.Dispose();
        }
        base.Dispose(disposing);
    }
}
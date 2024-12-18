using System.Threading.Tasks;
using Blazorise;
using System;
using System.Collections.Generic;
using Syrna.AuditLogging.Blazor.Components;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.EntityActions;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.TableColumns;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using Syrna.AuditLogging.Localization;
using Syrna.AuditLogging.Dtos;
using Volo.Abp.ObjectExtending;
using Microsoft.AspNetCore.Authorization;
using Syrna.AuditLogging.Permissions;

namespace Syrna.AuditLogging.Blazor.Pages.AuditLogging;

public partial class AuditLogPage
{
    private DetailsModal DetailsModalRef { get; set; }
    private PageToolbar Toolbar { get; } = new();

    private List<TableColumn> AuditLogTableColumns => TableColumns.Get<AuditLogListDto>();

    public AuditLogPage()
    {
        ObjectMapperContext = typeof(AuditLoggingBlazorModule);
        LocalizationResource = typeof(AuditLoggingResource);
    }

    protected override async Task GetEntitiesAsync()
    {
        try
        {
            await UpdateGetListInputAsync();
            var result = await AppService.GetListAsync(GetListInput);
            Entities = MapToListViewModel(result.Items);
            TotalCount = (int?)result.TotalCount;
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }
    private IReadOnlyList<AuditLogListDto> MapToListViewModel(IReadOnlyList<AuditLogListDto> dtos)
    {
        return ObjectMapper.Map<IReadOnlyList<AuditLogListDto>, List<AuditLogListDto>>(dtos);
    }

    protected override async ValueTask SetBreadcrumbItemsAsync()
    {
        BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:AuditLogging"].Value));
        await base.SetBreadcrumbItemsAsync();
    }

    protected override ValueTask SetEntityActionsAsync()
    {
        EntityActions
            .Get<AuditLogListDto>()
            .AddRange(new EntityAction[]
            {
                    new EntityAction
                    {
                        Text = L["View"],
                        Visible = (data) => true,
                        Clicked = async (data) => { await DetailsModalRef.OpenDetailsModalAsync(data.As<AuditLogListDto>().Id); }
                    },
            });

        return base.SetEntityActionsAsync();
    }

    protected override async ValueTask SetTableColumnsAsync()
    {
        AuditLogTableColumns
            .AddRange(new TableColumn[]
            {
                    new TableColumn
                    {
                        Title = L["Actions"],
                        Actions = EntityActions.Get<AuditLogListDto>(),
                    },
                    new TableColumn
                    {
                        Title = L["ApplicationName"],
                        Sortable = true,
                        Data = nameof(AuditLogListDto.ApplicationName),
                    },
                    new TableColumn
                    {
                        Title = L["ClientIpAddress"],
                        Sortable = true,
                        Data = nameof(AuditLogListDto.ClientIpAddress),
                    },
                    new TableColumn
                    {
                        Title = L["HttpMethod"],
                        Sortable = true,
                        Data = nameof(AuditLogListDto.HttpMethod),
                    },
                    new TableColumn
                    {
                        Title = L["Url"],
                        Sortable = true,
                        Data = nameof(AuditLogListDto.Url),
                    },
                    new TableColumn
                    {
                        Title = L["ExecutionTime"],
                        Sortable = true,
                        Data = nameof(AuditLogListDto.ExecutionTime),
                    },
                    new TableColumn
                    {
                        Title = L["ExecutionDuration"],
                        Sortable = true,
                        Data = nameof(AuditLogListDto.ExecutionDuration),
                    },
                    new TableColumn
                    {
                        Title = L["HttpStatusCode"],
                        Sortable = true,
                        Data = nameof(AuditLogListDto.HttpStatusCode),
                    },
            });

        AuditLogTableColumns.AddRange(await GetExtensionTableColumnsAsync(AuditLoggingModuleExtensionConsts.ModuleName,
            AuditLoggingModuleExtensionConsts.EntityNames.AuditLog));

        await base.SetTableColumnsAsync();
    }

    protected bool HasDetailsPermission { get; set; }
    private string DetailsPolicyName = AuditLoggingPermissions.AuditLogs.Default;
    protected override async Task SetPermissionsAsync()
    {
        await base.SetPermissionsAsync();
        if (DetailsPolicyName != null)
        {
            HasDetailsPermission = await AuthorizationService.IsGrantedAsync(DetailsPolicyName);
        }
    }

    protected override ValueTask SetToolbarItemsAsync()
    {
        //Toolbar.AddButton("..", GotoParentId,
        //    "fas fa-folder");

        return base.SetToolbarItemsAsync();
    }
}
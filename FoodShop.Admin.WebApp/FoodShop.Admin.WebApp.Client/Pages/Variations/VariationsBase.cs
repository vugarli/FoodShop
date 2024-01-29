using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using FoodShop.Admin.WebApp.Client.Pages.Categories.ViewModels;
using FoodShop.Admin.WebApp.Client.Pages.Products.Dialogs.Create;
using FoodShop.Admin.WebApp.Client.Pages.Products.Dialogs.Update;
using FoodShop.Admin.WebApp.Client.Pages.Products.ViewModels;
using FoodShop.Admin.WebApp.Client.Pages.Variations.Dialogs.Create;
using FoodShop.Admin.WebApp.Client.Pages.Variations.Dialogs.Update;
using FoodShop.Admin.WebApp.Client.Pages.Variations.ViewModels;
using FoodShop.Admin.WebApp.Client.Services;
using FoodShop.Application.Categories;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;

namespace FoodShop.Admin.WebApp.Client.Pages.Variations
{
    public class VariationsBase : ComponentBase
    {

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        public MudDataGrid<VM_Variation>? _dataGrid { get; set; }

        public HashSet<VM_Variation> SelectedItems { get; set; } = new();
        [Inject]
        public IVariationService VariationService { get; set; }

        [Inject]
        public ICategoryService CategoryService { get; set; }

        public IEnumerable<VM_Category> Categories { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Categories = await CategoryService.GetCategories();
        }

        public async Task<GridData<VM_Variation>> LoadGridData(GridState<VM_Variation> state)
        {
            var response = await VariationService.GetPaginatedVariations(state.Page + 1, state.PageSize);

            GridData<VM_Variation> data = new()
            {
                Items = response.Data,
                TotalItems = response.RowCount
            };

            return data;
        }

        public void SelectedItemsChanged(HashSet<VM_Variation> items)
        {
            SelectedItems = items;
        }

        public async Task DisplayEditDialog(Guid Id)
        {
            DialogOptions options = new DialogOptions();
            options.FullWidth = true;
            var dialogparams = new DialogParameters<UpdateVariationDialog>();
            var variation = await VariationService.GetVariationById(Id);

            var updateVariation = new VM_UpdateVariation()
            {
                Id = variation.Id,
                Name = variation.Name,
                VariationOptions = variation.VariationOptions.ToList()
            };

            dialogparams.Add<VM_UpdateVariation>(x => x.UpdateModel, updateVariation);

            var dialog = await DialogService.ShowAsync<UpdateVariationDialog>("Update", dialogparams, options);
            using var result = dialog.Result;
            var dialogResult = await result;
            if (!dialogResult.Cancelled)
            {
                var data = dialogResult.Data;
                var updateResult = await VariationService.UpdateVariation(data as VM_UpdateVariation);            

                if (updateResult)
                {
                    Snackbar.Add("Updated!", Severity.Success);
                    await _dataGrid.ReloadServerData();
                }
                else
                {
                    Snackbar.Add("Update Fail", Severity.Error);
                }
            }
        }

        public async void DisplayCreateDialog()
        {
            var parameters = new DialogParameters<CreateVariationDialog>();
            var dialog = await DialogService.ShowAsync<CreateVariationDialog>("Crate Variation", parameters);
            using var task = dialog.Result;
            var resultDialog = await task;
            if (!resultDialog.Canceled)
            {
                var result = await VariationService.CreateVariation(resultDialog.Data as VM_CreateVariaiton);
                if (result)
                {
                    Snackbar.Add("Created", Severity.Success);
                    await _dataGrid.ReloadServerData();
                }
                else
                {
                    Snackbar.Add("Not Created", Severity.Error);
                }
            }
        }


        public async void DeleteSelectedProducts()
        {
            if (SelectedItems != null && SelectedItems.Count() > 0)
            {
                var res = await VariationService.DeleteVariations(SelectedItems.Select(p => p.Id));
                if (res)
                {
                    Snackbar.Add("Deleted", Severity.Success);
                    _dataGrid.SelectedItems = null;
                    await _dataGrid.ReloadServerData();
                }
                else
                {
                    Snackbar.Add("Delete op failed", Severity.Error);
                }
                SelectedItems.Clear();
            }
        }



    }
}

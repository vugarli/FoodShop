using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using FoodShop.Admin.WebApp.Client.Pages.ProductEntries.Dialogs.Create;
using FoodShop.Admin.WebApp.Client.Pages.ProductEntries.Dialogs.Update;
using FoodShop.Admin.WebApp.Client.Pages.ProductEntries.ViewModels;
using FoodShop.Admin.WebApp.Client.Pages.Products.Dialogs.Create;
using FoodShop.Admin.WebApp.Client.Pages.Products.Dialogs.Update;
using FoodShop.Admin.WebApp.Client.Pages.Products.ViewModels;
using FoodShop.Admin.WebApp.Client.Services;
using FoodShop.Application.Categories;
using FoodShop.Application.Queries;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;

namespace FoodShop.Admin.WebApp.Client.Pages.ProductEntries
{
    public class ProductEntriesBase : ComponentBase
    {
        [Inject]
        public IProductEntryService ProductEntryService{ get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }
        [Inject]
        public IDialogService DialogService { get; set; }


        public IEnumerable<VM_Product> Products { get; set; }

        public HashSet<VM_ProductEntry> SelectedItems { get; set; } = new();

        public MudDataGrid<VM_ProductEntry> _dataGrid { get; set; }


        protected override async Task OnInitializedAsync()
        {
            var client = ClientFactory.CreateClient("API");

            var response = await client.GetFromJsonAsync<QueryResult<VM_Product>>($"/products?page={1}&per_page={50}");
            Products = response.Data.ToList();
        }


        public async Task<GridData<VM_ProductEntry>> LoadGridData(GridState<VM_ProductEntry> state)
        {
            var response = await ProductEntryService.GetPaginatedProductEntries(state.Page + 1, state.PageSize);

            GridData<VM_ProductEntry> data = new()
            {
                Items = response.Data,
                TotalItems = response.RowCount
            };

            return data;
        }

        public void SelectedItemsChanged(HashSet<VM_ProductEntry> items)
        {
            SelectedItems = items;
        }


        public async Task DisplayCreateDialog()
        {
            var parameters = new DialogParameters<CreateProductEntryDialogBase>();
            
            parameters.Add<IEnumerable<VM_Product>>(x => x.Products, Products);
            
            var dialog = await DialogService.ShowAsync<CreateProductEntryDialog>("Crate ProductEntry", parameters);
            using var task = dialog.Result;
            var resultDialog = await task;
            if (!resultDialog.Canceled)
            {
                var result = await ProductEntryService.CreateProductEntry(resultDialog.Data as VM_CreateProductEntry);
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

        public async Task DisplayEditDialog(Guid Id)
        {
            DialogOptions options = new DialogOptions();
            options.FullWidth = true;
            var dialogparams = new DialogParameters<UpdateProductEntryDialog>();
            var product = await ProductEntryService.GetProductEntryById(Id);

            var updateProd = new VM_UpdateProductEntry()
            {
                Id = product.Id,
                Price = product.Price,
                SKU = product.SKU,
                Quantity = product.Quantity,
                Image = product.Image,
                ProductId = product.ProductId
            };

            dialogparams.Add<IEnumerable<VM_Product>>(x => x.Products, Products);
            dialogparams.Add<VM_UpdateProductEntry>(x => x.UpdateModel, updateProd);

            var dialog = await DialogService.ShowAsync<UpdateProductEntryDialog>("Update", dialogparams, options);
            using var result = dialog.Result;
            var dialogResult = await result;

            if (!dialogResult.Cancelled)
            {
                var data = dialogResult.Data;

                var client = ClientFactory.CreateClient("API");
                var updateResult = await client.PutAsJsonAsync($"/productentries/{Id}", data);

                if (updateResult.IsSuccessStatusCode)
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

        public async Task DeleteSelectedProducts()
        {
            if (SelectedItems != null && SelectedItems.Count() > 0)
            {
                var res = await ProductEntryService.DeleteProductEntries(SelectedItems.Select(p => p.Id));
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

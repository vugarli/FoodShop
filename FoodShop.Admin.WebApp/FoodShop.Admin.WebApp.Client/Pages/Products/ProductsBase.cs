using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using FoodShop.Admin.WebApp.Client.Pages.Products.Dialogs.Create;
using FoodShop.Admin.WebApp.Client.Pages.Products.Dialogs.Update;
using FoodShop.Admin.WebApp.Client.Pages.Products.ViewModels;
using FoodShop.Application.Categories;
using FoodShop.Application.Queries;
using FoodShop.Application.Products;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Net.Http.Json;


namespace FoodShop.Admin.WebApp.Client.Pages.Products
{
    public class ProductsBase : ComponentBase
    {
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        
        [Inject]
        public IProductService ProductService { get; set; }
        
        [Inject]
        public ISnackbar Snackbar{ get; set; }


        [Inject]
        public IDialogService DialogService { get; set; }

        public MudDataGrid<VM_Product>? _dataGrid { get; set; }

        public HashSet<VM_Product> SelectedItems { get; set; } = new();

        public List<CategoryDto> Categories { get; set; }


        public MudForm form;
        public bool success;
        public string[] errors = { };


        public VM_CreateProduct ProductVM { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            var client = ClientFactory.CreateClient("API");

            var response = await client.GetFromJsonAsync<PaginatedQueryResult<CategoryDto>>($"/categories?page={1}&per_page={50}");
            Categories = response.Data.ToList();
        }

        public async Task<GridData<VM_Product>> LoadGridData(GridState<VM_Product> state)
        {
            var response = await ProductService.GetPaginatedProducts(state.Page+1, state.PageSize);
            
            GridData<VM_Product> data = new()
            {
                Items = response.Data,
                TotalItems = response.RowCount
            };

            return data;
        }

        public void SelectedItemsChanged(HashSet<VM_Product> items)
        {
            SelectedItems = items;
        }

        public async void DeleteSelectedProducts()
        {
            if(SelectedItems!= null && SelectedItems.Count() > 0)
            {
                var res = await ProductService.DeleteProducts(SelectedItems.Select(p=>p.Id));
                if(res)
                {
                    Snackbar.Add("Deleted", Severity.Success);
                    _dataGrid.SelectedItems = null;
                    await _dataGrid.ReloadServerData();
                }else
                {
                    Snackbar.Add("Delete op failed", Severity.Error);
                }
                SelectedItems.Clear();
            }
        }


        // use for soft deleted row RowStyleFunc="@RowStyle"
        public string RowStyle(VM_Product product,int i)
        {
            if(product.Id == Guid.Parse("40b881bc-d311-4e18-8415-24a4d4ee2cbc"))
            {
                return "background-color: red;";
            }
            return null;
        }
        public async Task DisplayEditDialog(Guid Id)
        {
            DialogOptions options = new DialogOptions();
            options.FullWidth = true;
            var dialogparams = new DialogParameters<UpdateProductDialog>();
            //dialogparams.Add<IEnumerable<CategoryDto>>(x => x.Categories, Categories);
            var product = await ProductService.GetProductById(Id);
            var updateProd = new VM_UpdateProduct()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Image = product.Image,
                CategoryId = product.CategoryId
            };
            dialogparams.Add<IEnumerable<CategoryDto>>(x => x.Categories, Categories);
            dialogparams.Add<VM_UpdateProduct>(x => x.UpdateModel, updateProd);

            var dialog = await DialogService.ShowAsync<UpdateProductDialog>("Update",dialogparams,options);
            using var result = dialog.Result;
            var dialogResult = await result;
            if(!dialogResult.Cancelled)
            {
                var data = dialogResult.Data;
                var client = ClientFactory.CreateClient("API");
                var updateResult = await client.PutAsJsonAsync($"/products/{Id}", data);
                if(updateResult.IsSuccessStatusCode)
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
            var parameters = new DialogParameters<CreateProductDialog>();
            parameters.Add<IEnumerable<CategoryDto>>(x => x.Categories, Categories);
            var dialog = await DialogService.ShowAsync<CreateProductDialog>("Crate Product",parameters);
            using var task = dialog.Result;
            var resultDialog = await task;
            if (!resultDialog.Canceled)
            {
                var result = await ProductService.CreateProduct(resultDialog.Data as VM_CreateProduct);
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


    }
}

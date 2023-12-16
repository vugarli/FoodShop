﻿using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using FoodShop.Admin.WebApp.Client.Pages.Products.Dialogs.Create;
using FoodShop.Admin.WebApp.Client.Pages.Products.Dialogs.Update;
using FoodShop.Application.Categories;
using FoodShop.Application.Pagination;
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

        public MudDataGrid<ProductDto>? _dataGrid;

        public HashSet<VM_Product> SelectedItems { get; set; } = new();

        public List<CategoryDto> Categories { get; set; }


        public MudForm form;
        public bool success;
        public string[] errors = { };


        public VM_CreateProduct ProductVM { get; set; } = new();


        public bool isVisibleOverlay { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var client = ClientFactory.CreateClient("API");

            var response = await client.GetFromJsonAsync<PaginatedResult<CategoryDto>>($"/categories?page={1}&per_page={50}");
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
            dialogparams.Add<IEnumerable<CategoryDto>>(x => x.Categories, Categories);
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
            dialogparams.Add<VM_UpdateProduct>(x => x.ProductVM, updateProd);

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
                var client = ClientFactory.CreateClient("API");
                var result = await client.PostAsJsonAsync("/products", resultDialog.Data);
                if (result.IsSuccessStatusCode)
                {
                    Snackbar.Add("Created", Severity.Success);
                }
                else
                {
                    Snackbar.Add("Not Created", Severity.Error);
                }
            }
        }


    }
}
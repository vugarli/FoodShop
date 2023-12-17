using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using FoodShop.Admin.WebApp.Client.Pages.Categories.Dialogs.Create;
using FoodShop.Admin.WebApp.Client.Pages.Categories.Dialogs.Update;
using FoodShop.Admin.WebApp.Client.Pages.Categories.ViewModels;
using FoodShop.Admin.WebApp.Client.Pages.Products.Dialogs.Create;
using FoodShop.Admin.WebApp.Client.Pages.Products.Dialogs.Update;
using FoodShop.Admin.WebApp.Client.Pages.Products.ViewModels;
using FoodShop.Application.Categories;
using FoodShop.Application.Pagination;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;

namespace FoodShop.Admin.WebApp.Client.Pages.Categories
{
    public class CategoriesBase : ComponentBase
    {
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }

        [Inject]
        public ICategoryService CategoryService { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }


        [Inject]
        public IDialogService DialogService { get; set; }

        public MudDataGrid<VM_Category>? _dataGrid { get; set; }

        public HashSet<VM_Category> SelectedItems { get; set; } = new();

        public List<VM_Category> ParentCategories { get; set; }


        public MudForm form;
        public bool success;
        public string[] errors = { };


        public VM_CreateCategory CategoryVM { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            ParentCategories = (await CategoryService.GetParentCategories()).ToList();
            
        }

        public async Task<GridData<VM_Category>> LoadGridData(GridState<VM_Category> state)
        {
            var response = await CategoryService.GetPaginatedCategories(state.Page + 1, state.PageSize);

            GridData<VM_Category> data = new()
            {
                Items = response.Data,
                TotalItems = response.RowCount
            };

            return data;
        }

        public void SelectedItemsChanged(HashSet<VM_Category> items)
        {
            SelectedItems = items;
        }

        public async void DeleteSelectedCategories()
        {
            if (SelectedItems != null && SelectedItems.Count() > 0)
            {
                var res = await CategoryService.DeleteCategories(SelectedItems.Select(p => p.Id));
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


        // use for soft deleted row RowStyleFunc="@RowStyle"
        public string RowStyle(VM_Category category, int i)
        {
            if (category.Id == Guid.Parse("40b881bc-d311-4e18-8415-24a4d4ee2cbc"))
            {
                return "background-color: red;";
            }
            return null;
        }
        public async Task DisplayEditDialog(Guid Id)
        {
            DialogOptions options = new DialogOptions();
            options.FullWidth = true;
            var dialogparams = new DialogParameters<UpdateCategoriesDialog>();
            dialogparams.Add<IEnumerable<VM_Category>>(x => x.ParentCategories, ParentCategories);

            var category = await CategoryService.GetCategoryById(Id);
            var updateCategory = new VM_UpdateCategory()
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId
            };

            dialogparams.Add<VM_UpdateCategory>(x => x.CategoryVM, updateCategory);

            var dialog = await DialogService.ShowAsync<UpdateCategoriesDialog>("Update", dialogparams, options);
            using var result = dialog.Result;
            var dialogResult = await result;
            if (!dialogResult.Cancelled)
            {
                var data = dialogResult.Data;
                var client = ClientFactory.CreateClient("API");
                var updateResult = await client.PutAsJsonAsync($"/categories/{Id}", data);
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
        public async void DisplayCreateDialog()
        {
            var parameters = new DialogParameters<CreateCategoryDialog>();
            parameters.Add<IEnumerable<VM_Category>>(x => x.ParentCategories, ParentCategories);
            var dialog = await DialogService.ShowAsync<CreateCategoryDialog>("Crate Category", parameters);
            using var task = dialog.Result;
            var resultDialog = await task;
            if (!resultDialog.Canceled)
            {
                var result = await CategoryService.CreateCategory(resultDialog.Data as VM_CreateCategory);
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

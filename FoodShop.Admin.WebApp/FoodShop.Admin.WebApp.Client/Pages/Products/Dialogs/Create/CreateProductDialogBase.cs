using FoodShop.Admin.WebApp.Client.Pages;
using FoodShop.Admin.WebApp.Client.Pages.Products;
using FoodShop.Application.Categories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace FoodShop.Admin.WebApp.Client.Pages
{
    public class CreateProductDialogBase : ComponentBase
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        

        [Parameter]
        public List<CategoryDto> Categories { get; set; } = new();

        public EditForm _editForm { get; set; }

        public VM_CreateProduct ProductVM { get; set; } = new();


        public async Task Create()
        {
            if (_editForm?.EditContext?.Validate() ?? false)
            {
                MudDialog.Close(DialogResult.Ok(ProductVM));
            }
        }

        public void Cancel()
        {
            MudDialog.Cancel();
        }
    }
}

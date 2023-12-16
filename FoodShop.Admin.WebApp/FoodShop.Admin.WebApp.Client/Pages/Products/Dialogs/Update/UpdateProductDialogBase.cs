using FoodShop.Application.Categories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace FoodShop.Admin.WebApp.Client.Pages.Products.Dialogs.Update
{
    public class UpdateProductDialogBase : ComponentBase
    {
        
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public VM_UpdateProduct ProductVM{ get; set; }

        public EditForm _editForm { get; set; }

        [Parameter]
        public List<CategoryDto> Categories { get; set; } = new();

        
        public void Update()
        {
            if(_editForm?.EditContext?.Validate() ?? false)
            {
                MudDialog.Close(DialogResult.Ok(ProductVM));
            }
        }

        public void Cancel()
        {
            MudDialog.Close(DialogResult.Cancel());
        }

    }
}

using FoodShop.Admin.WebApp.Client.Pages.Categories.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace FoodShop.Admin.WebApp.Client.Pages.Categories.Dialogs.Update
{
    public class UpdateCategoriesDialogBase: ComponentBase
    {

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        public EditForm _editForm { get; set; }

        [Parameter]
        public VM_UpdateCategory CategoryVM { get; set; } = new();

        [Parameter]
        public List<VM_Category> ParentCategories { get; set; }

        public void Create()
        {
            if (_editForm?.EditContext?.Validate() ?? false)
            {
                MudDialog.Close(DialogResult.Ok(CategoryVM));
            }
            else
            {
                MudDialog.Close(DialogResult.Cancel());
            }
        }

        public void Cancel()
        {
            MudDialog.Close(DialogResult.Cancel());
        }

    }
}

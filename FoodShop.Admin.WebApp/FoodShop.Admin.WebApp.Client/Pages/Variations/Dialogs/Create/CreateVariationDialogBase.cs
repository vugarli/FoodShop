using FoodShop.Admin.WebApp.Client.Pages.Categories.ViewModels;
using FoodShop.Admin.WebApp.Client.Pages.Variations.ViewModels;
using FoodShop.Admin.WebApp.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace FoodShop.Admin.WebApp.Client.Pages.Variations.Dialogs.Create
{
    public class CreateVariationDialogBase : ComponentBase
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        public VM_CreateVariaiton CreateModel { get; set; } = new();

        protected EditForm _editForm { get; set; }
        

        public async Task Create()
        {
            if (_editForm?.EditContext?.Validate() ?? false)
            {
                MudDialog.Close(DialogResult.Ok(CreateModel));
            }
        }

        public void AddVariationOption()
        {
            CreateModel.VariationOptions.Add(new VM_CreateVariationOption());
        }

        public void Cancel()
        {
            MudDialog.Cancel();
        }

    }
}

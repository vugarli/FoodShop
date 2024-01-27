using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using FoodShop.Admin.WebApp.Client.Pages.ProductEntries.ViewModels;
using FoodShop.Admin.WebApp.Client.Pages.Products.ViewModels;
using FoodShop.Application.Categories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace FoodShop.Admin.WebApp.Client.Pages.ProductEntries.Dialogs.Create
{
    public class CreateProductEntryDialogBase : ComponentBase
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        public VM_CreateProductEntry CreateModel { get; set; } = new();

        public EditForm _editForm { get; set; }

        [Parameter]
        public List<VM_Product> Products { get; set; } = new List<VM_Product>();

        public IBrowserFile SelectedFile { get; set; }

        [Inject]
        IFileUploadService fileUploadService { get; set; }


        public string ImageData { get; set; }


        public async void Create()
        {
            if (SelectedFile != null)
                    CreateModel.Image = await fileUploadService.UploadFileAndProvideNameAsync(SelectedFile);
            if (_editForm?.EditContext?.Validate() ?? false)
            {
                MudDialog.Close(DialogResult.Ok(CreateModel));
            }
        }

        public void Cancel()
        {
            MudDialog.Cancel();
        }

    }
}

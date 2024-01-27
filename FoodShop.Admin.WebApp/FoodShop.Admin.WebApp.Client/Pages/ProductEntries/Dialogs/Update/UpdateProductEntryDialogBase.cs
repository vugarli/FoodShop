using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using FoodShop.Admin.WebApp.Client.Pages.ProductEntries.ViewModels;
using FoodShop.Admin.WebApp.Client.Pages.Products.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace FoodShop.Admin.WebApp.Client.Pages.ProductEntries.Dialogs.Update
{
    public class UpdateProductEntryDialogBase : ComponentBase
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        public EditForm _editForm { get; set; }

        [Parameter]
        public VM_UpdateProductEntry UpdateModel { get; set; }
        
        [Parameter]
        public List<VM_Product> Products { get; set; } = new List<VM_Product>();

        public IBrowserFile SelectedFile { get; set; }

        [Inject]
        IFileUploadService fileUploadService { get; set; }

        public string ImageData { get; set; }

        protected override void OnInitialized()
        {
            ImageData = $"http://localhost:9000/photos/{UpdateModel.Image}";
            base.OnInitialized();
        }

        public async Task Update()
        {
            if (SelectedFile != null)
                    UpdateModel.Image = await fileUploadService.UploadFileAndProvideNameAsync(SelectedFile);
            if (_editForm?.EditContext?.Validate() ?? false)
            {
                MudDialog.Close(DialogResult.Ok(UpdateModel));
            }
        }

        public void Cancel()
        {
            MudDialog.Cancel();
        }

    }
}

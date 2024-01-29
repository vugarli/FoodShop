using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using FoodShop.Admin.WebApp.Client.Pages;
using FoodShop.Admin.WebApp.Client.Pages.Products.ViewModels;
using FoodShop.Application.Categories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Xml.Linq;

namespace FoodShop.Admin.WebApp.Client.Pages
{
    public class CreateProductDialogBase : ComponentBase
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public List<CategoryDto> Categories { get; set; } = new();


        public EditForm _editForm { get; set; }

        public IBrowserFile SelectedFile { get; set; }

        public VM_CreateProduct CreateModel { get; set; } = new();

        [Inject]
        IFileUploadService fileUploadService { get; set; }


        public async Task Create()
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

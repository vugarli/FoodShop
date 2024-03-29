﻿using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using FoodShop.Admin.WebApp.Client.Pages.Products.ViewModels;
using FoodShop.Admin.WebApp.Client.Services;
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
        public VM_UpdateProduct UpdateModel{ get; set; }

        public IBrowserFile SelectedFile { get; set; }

        public string ImageData { get; set; }

        public EditForm _editForm { get; set; }

        [Inject]
        IFileUploadService fileUploadService { get; set; }

        [Parameter]
        public List<CategoryDto> Categories { get; set; } = new();

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
            MudDialog.Close(DialogResult.Cancel());
        }

    }
}

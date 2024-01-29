using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using FoodShop.Admin.WebApp.Client.Pages.Variations.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace FoodShop.Admin.WebApp.Client.Pages.Variations.Dialogs.Update
{
    public class UpdateVariationDialogBase : ComponentBase
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public VM_UpdateVariation UpdateModel { get; set; }

        protected EditForm _editForm { get; set; }
        [Inject]
        IVariationOptionService VariationOptionService { get; set; }
        [Inject]
        IVariationService VariationService { get; set; }


        public async Task Update()
        {
            if (_editForm?.EditContext?.Validate() ?? false)
            {
                MudDialog.Close(DialogResult.Ok(UpdateModel));
            }
        }

        public async Task<bool> ReloadModel()
        {
            var result = await VariationService.GetVariationById(UpdateModel.Id);
            if (result != null)
            { 
                UpdateModel = new VM_UpdateVariation { Id = result.Id,Name=result.Name,VariationOptions=result.VariationOptions.ToList() };
                return true;
            }
            return false;
        }

        public async Task DeleteVariationOption(VM_UpdateVariationOption variationOption)
        {
            if (variationOption.Id == default) UpdateModel.VariationOptions.Remove(variationOption);
            var result = await VariationOptionService.DeleteVariatonOptionAsync(variationOption.Id);
            if (result)
            {
                await ReloadModel();
            }    
        }

        public void AddVariationOption()
        {
            UpdateModel.VariationOptions.Add(new VM_UpdateVariationOption());
        }

        public void Cancel()
        {
            MudDialog.Cancel();
        }

    }
}

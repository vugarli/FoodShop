using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using FoodShop.Admin.WebApp.Client.Pages.Categories.ViewModels;
using FoodShop.Admin.WebApp.Client.Pages.Variations.ViewModels;
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
        public VM_UpdateCategory UpdateModel { get; set; } = new();

        [Parameter]
        public List<VM_Category> ParentCategories { get; set; }

        [Inject]
        ICategoryService CategoryService { get; set; }

        [Inject]
        IVariationService VariationService { get; set; }

        public List<VM_Variation> OwnedVariations { get; set; }
        public List<VM_Variation> Variations { get; set; }
        
        public List<VM_Variation> VariationsToBeAdded { get => Variations.Where(v => !OwnedVariations.Any(a => a.Id == v.Id)).ToList(); }

        public Guid SelectedVariation { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Variations = (await VariationService.GetVariations()).ToList();
            await LoadVariations();
        }

        public void Create()
        {
            if (_editForm?.EditContext?.Validate() ?? false)
            {
                MudDialog.Close(DialogResult.Ok(UpdateModel));
            }
            else
            {
                MudDialog.Close(DialogResult.Cancel());
            }
        }

        public async Task RemoveVariation(Guid variationId)
        {
            await CategoryService.RemoveVariation(UpdateModel.Id,variationId);
            await LoadVariations();
        }

        public async Task AddVariation()
        {
            await CategoryService.AddVariation(UpdateModel.Id, SelectedVariation);
            await LoadVariations();
            SelectedVariation = default;
        }

        public async Task LoadVariations()
        {
            OwnedVariations = (await CategoryService.GetVariations(UpdateModel.Id)).ToList();
        }


        public void Cancel()
        {
            MudDialog.Close(DialogResult.Cancel());
        }

    }
}

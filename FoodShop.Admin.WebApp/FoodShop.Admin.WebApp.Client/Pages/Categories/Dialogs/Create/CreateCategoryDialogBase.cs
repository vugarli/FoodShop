using FoodShop.Admin.WebApp.Client.Components.FormValidation;
using FoodShop.Admin.WebApp.Client.Pages.Categories.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using MudBlazor;
using System.Reflection;

namespace FoodShop.Admin.WebApp.Client.Pages.Categories.Dialogs.Create
{

    public class CreateCategoryDialogBase : ComponentBase
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        public VM_CreateCategory CreateModel { get; set; } = new();

        public EditForm _editForm { get; set; }

        [Parameter]
        public List<VM_Category> ParentCategories { get; set; }

        [Parameter]
        public List<VM_Gender> Genders { get; set; }

        protected CustomValidationComponent _customValidator { get; set; }

        public void Create()
        {

            _customValidator?.ClearErrors();

            var errors = new Dictionary<string, List<string>>();
            
            if (CreateModel!.ParentId != null &&
                    CreateModel.BaseDiscriminatorId == null)
            {
                errors.Add(nameof(CreateModel.BaseDiscriminatorId),
                    new() { "You should choose gender!" });
            }


            if (errors.Any())
            {
                _customValidator?.DisplayErrors(errors);
            }
            else
            {
                MudDialog.Close(DialogResult.Ok(CreateModel));
            }

        }

        public void Cancel()
        {
            MudDialog.Close(DialogResult.Cancel());
        }
    }
}

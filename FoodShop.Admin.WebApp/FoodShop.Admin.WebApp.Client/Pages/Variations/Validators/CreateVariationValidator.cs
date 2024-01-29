using FluentValidation;
using FoodShop.Admin.WebApp.Client.Pages.Variations.ViewModels;

namespace FoodShop.Admin.WebApp.Client.Pages.Variations.Validators
{
    public class CreateVariationValidator : AbstractValidator<VM_CreateVariaiton>
    {
        public CreateVariationValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleForEach(x => x.VariationOptions).ChildRules(c => { 
                c.RuleFor(a => a.Value).NotEmpty().WithMessage("Variation Option value should not be empty!");
                c.RuleFor(a => a.Name).NotEmpty().WithMessage("Variation Option name should not be empty!");
            });
        }


    }
}

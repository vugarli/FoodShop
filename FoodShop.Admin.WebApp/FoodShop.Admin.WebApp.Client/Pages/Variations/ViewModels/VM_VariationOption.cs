using System.ComponentModel.DataAnnotations;

namespace FoodShop.Admin.WebApp.Client.Pages.Variations.ViewModels
{
    public class VM_CreateVariationOption
    {
        public string Value { get; set; }
        public string Name { get; set; }
    }
    public class VM_UpdateVariationOption
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
    }

    public class VM_VariationOption
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
    }

}

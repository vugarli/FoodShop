namespace FoodShop.Admin.WebApp.Client.Pages.Variations.ViewModels
{
    public class VM_Variation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<VM_UpdateVariationOption> VariationOptions { get; set; }
    }
}

using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace FoodShop.Admin.WebApp.Client.Pages.Variations.ViewModels
{
    public class VM_UpdateVariation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<VM_UpdateVariationOption> VariationOptions { get; set; } = new();
    }
}

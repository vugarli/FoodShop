using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodShop.Admin.WebApp.Client.Pages.Variations.ViewModels
{
    public class VM_CreateVariaiton
    {
        public string Name { get; set; }
        public List<VM_CreateVariationOption> VariationOptions { get; set; } = new();
    }
}

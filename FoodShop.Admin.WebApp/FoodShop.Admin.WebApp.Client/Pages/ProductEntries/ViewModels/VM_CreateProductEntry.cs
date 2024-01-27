using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace FoodShop.Admin.WebApp.Client.Pages.ProductEntries.ViewModels
{
    public class VM_CreateProductEntry
    {
        [Required]
        [RegularExpression("^((?!00000000-0000-0000-0000-000000000000).)*$", ErrorMessage = "Select Valid Product")]
        public Guid ProductId { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}

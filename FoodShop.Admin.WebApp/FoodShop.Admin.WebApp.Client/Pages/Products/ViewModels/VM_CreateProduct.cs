using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace FoodShop.Admin.WebApp.Client.Pages.Products.ViewModels
{
    //TODO add messages
    public class VM_CreateProduct
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        public string Description { get; set; }

        [Required]
        [RegularExpression("^((?!00000000-0000-0000-0000-000000000000).)*$", ErrorMessage = "Invalid Guid")]
        public Guid CategoryId { get; set; }
        [Required]
        public string Image { get; set; }

    }
}

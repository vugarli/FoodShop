using System.ComponentModel.DataAnnotations;

namespace FoodShop.Admin.WebApp.Client.Pages.Products.ViewModels
{
    public class VM_UpdateProduct
    {
        [Required]
        [RegularExpression("^((?!00000000-0000-0000-0000-000000000000).)*$", ErrorMessage = "Invalid Guid")]
        public Guid Id { get; set; }

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

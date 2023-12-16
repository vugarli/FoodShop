using System.ComponentModel.DataAnnotations;

namespace FoodShop.Admin.WebApp.Client.Pages.Products
{
    public class VM_Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

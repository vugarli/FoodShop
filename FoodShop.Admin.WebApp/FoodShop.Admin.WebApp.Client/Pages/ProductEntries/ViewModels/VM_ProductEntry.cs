namespace FoodShop.Admin.WebApp.Client.Pages.ProductEntries.ViewModels
{
    public class VM_ProductEntry
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
    }
}

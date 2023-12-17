namespace FoodShop.Admin.WebApp.Client.Pages.Categories.ViewModels
{
    public class VM_UpdateCategory
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }

    }
}

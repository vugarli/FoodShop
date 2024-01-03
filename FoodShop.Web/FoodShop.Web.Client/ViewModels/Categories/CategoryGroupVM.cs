namespace FoodShop.Web.ViewModels.Categories
{
    public class CategoryGroupVM
    {
        public string CategoryGroupName { get; set; }
        public Guid CategoryGroupId { get; set; }
        public IEnumerable<CategoryGroupItemVM> SubCategories { get; set; }
    }
    public record CategoryGroupItemVM(string Name,Guid Id);

    public class BaseDiscriminatorGroupVM
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public IEnumerable<CategoryGroupVM> Groups { get; set; }
    }

}

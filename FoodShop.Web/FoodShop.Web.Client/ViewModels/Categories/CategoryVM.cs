namespace FoodShop.Web.ViewModels.Categories
{
    public class CategoryVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
        public Nullable<Guid> ParentId { get; set; }

        public Nullable<Guid> BaseCategoryDiscriminatorId { get; set; }
        public string BaseCategoryDiscriminatorName { get; set; }
    }
}

using FoodShop.Web.ViewModels.Products;

namespace FoodShop.Web.Client.Services
{
    public interface ILatesArrivalsProductServices
    {
        public Task<IEnumerable<IEnumerable<ProductItemViewModel>>> GetLatestArrivalsGroups();
    }
}

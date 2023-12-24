using FoodShop.Web.ViewModels.Products;

namespace FoodShop.Web.Abstractions.Services
{
    public interface ILatesArrivalsProductServices
    {
        public Task<IEnumerable<ProductItemViewModel>> GetLatestArrivals();
    }
}

using FoodShop.Web.ViewModels.Products;

namespace FoodShop.Web.Client.Abstractions.Services
{
    public interface IFilteredProductEntryService
    {
        Task<IEnumerable<ProductItemViewModel>> GetFilteredProductEntries(Dictionary<string, string> queryParams);
    }
}

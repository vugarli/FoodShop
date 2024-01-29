using FoodShop.Admin.WebApp.Client.Pages.Products.ViewModels;
using FoodShop.Admin.WebApp.Client.Pages.Variations.ViewModels;
using FoodShop.Application.Queries;

namespace FoodShop.Admin.WebApp.Client.Abstractions.Services
{
    public interface IVariationService
    {
        public Task<bool> DeleteVariation(Guid id);
        public Task<bool> DeleteVariations(IEnumerable<Guid> ids);
        public Task<bool> CreateVariation(VM_CreateVariaiton model);
        public Task<bool> UpdateVariation(VM_UpdateVariation model);
        public Task<VM_Variation> GetVariationById(Guid id);
        public Task<IEnumerable<VM_Variation>> GetVariations();
        public Task<PaginatedQueryResult<VM_Variation>> GetPaginatedVariations(int page, int per_page);
    }
}

using FoodShop.Admin.WebApp.Client.Pages.ProductEntries.ViewModels;
using FoodShop.Application.Queries;

namespace FoodShop.Admin.WebApp.Client.Abstractions.Services
{
    public interface IProductEntryService
    {
        public Task<bool> DeleteProductEntry(Guid id);
        public Task<bool> DeleteProductEntries(IEnumerable<Guid> ids);

        public Task<bool> CreateProductEntry(VM_CreateProductEntry product);
        public Task<bool> UpdateProductEntry(VM_UpdateProductEntry product);
        public Task<VM_ProductEntry> GetProductEntryById(Guid id);
        public Task<IEnumerable<VM_ProductEntry>> GetProductEntries();
        public Task<PaginatedQueryResult<VM_ProductEntry>> GetPaginatedProductEntries(int page, int per_page);
    }
}

using FoodShop.Application.VariationOptions;
using FoodShop.Domain.Entities;

namespace FoodShop.Application.Abstractions;

public interface IVariationOptionRepository
{
    public Task<VariationOption> GetVariationOptionByIdAsync(Guid id);

    public Task<IEnumerable<VariationOption>> GetVariationOptionsAsync();
    public Task<IEnumerable<VariationOption>> GetPaginatedVariationOptionsAsync(int page,int per_page);

    public Task CreateVariationOptionAsync(VariationOption variationOption);

    public Task<VariationOption> UpdateVariationOptionAsync(VariationOption variationOption);

    public Task DeleteVariationOptionAsync(Guid id);

    public Task<bool> VariationOptionExistsAsync(Guid id,CancellationToken cancellationToken);
    public Task<int> GetVariationOptionsCountAsync();

}
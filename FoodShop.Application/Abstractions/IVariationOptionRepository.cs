using FoodShop.Application.VariationOptions;
using FoodShop.Domain.Entities;

namespace FoodShop.Application.Abstractions;

public interface IVariationOptionRepository
{
    public Task<VariationOption> GetVariationOptionByIdAsync(Guid id);

    public Task<IEnumerable<VariationOption>> GetVariationOptionsAsync();

    public Task CreateVariationOptionAsync(VariationOption variationOption);

    public Task<VariationOption> UpdateVariationOptionAsync(VariationOption variationOption);

    public Task DeleteVariationOptionAsync(Guid id);

    public Task<bool> VariationOptionExistsAsync(Guid id,CancellationToken cancellationToken);
}
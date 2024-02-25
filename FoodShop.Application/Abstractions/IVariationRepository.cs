using FoodShop.Application.Filters;
using FoodShop.Domain.Entities;

namespace FoodShop.Application.Abstractions;

public interface IVariationRepository
{
    public Task<Variation> CreateVariationAsync(Variation variation);
    public Task<Variation> GetVariationByIdAsync(Guid id);
    public Task<bool> VariationExistsAsync(Guid id,CancellationToken cancellationToken);
    public Task<bool> VariationsExistsAsync(IEnumerable<Guid> ids,CancellationToken cancellationToken);
    public Task<IEnumerable<Variation>> GetFilteredVariationsAsync(params IFilter<Variation>[] filters);
    public Task<Variation> UpdateVariationAsync(Variation variation);
    public Task DeleteVariationAsync(Guid id);
    public Task DeleteVariationsAsync(IEnumerable<Guid> ids);
    public Task<int> GetVariationsCountAsync();
}
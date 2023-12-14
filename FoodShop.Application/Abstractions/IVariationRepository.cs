using FoodShop.Domain.Entities;

namespace FoodShop.Application.Abstractions;

public interface IVariationRepository
{
    public Task<Variation> CreateVariationAsync(Variation variation);
    
    public Task<Variation> GetVariationByIdAsync(Guid id);
    public Task<bool> VariationExistsAsync(Guid id,CancellationToken cancellationToken);
    public Task<IEnumerable<Variation>> GetVariationsAsync();
    public Task<IEnumerable<Variation>> GetPaginatedVariationsAsync(int page,int per_page);

    public Task<Variation> UpdateVariationAsync(Variation variation);

    public Task DeleteVariationAsync(Guid id);
    public Task<int> GetVariationsCountAsync();
}
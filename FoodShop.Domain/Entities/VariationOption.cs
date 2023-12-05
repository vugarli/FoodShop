using FoodShop.Domain.Primitives;

namespace FoodShop.Domain.Entities;

public class VariationOption : Entity
{
    public VariationOption(Guid id, Guid variationId, string value) : base(id)
    {
        VariationId = variationId;
        Value = value;
    }

    public Guid VariationId { get; private set; }
    public Variation Variation { get; private set; }

    public string Value { get; private set; }

    public IEnumerable<ProductEntry> ProductEntries { get; private set; }
}
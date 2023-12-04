using FoodShop.Domain.Primitives;

namespace FoodShop.Domain.Entities;

public class VariationOption : Entity
{
    public VariationOption(Guid id, int variationId, string value) : base(id)
    {
        VariationId = variationId;
        Value = value;
    }

    public int VariationId { get; private set; }
    public Variation Variation { get; private set; }

    public string Value { get; private set; }

    public IEnumerable<ProductEntry> ProductEntries { get; private set; }
}
using FoodShop.Domain.Primitives;

namespace FoodShop.Domain.Entities;

public class VariationOption : Entity
{
    public VariationOption(Guid id, Guid variationId, string value, string name) : base(id)
    {
        VariationId = variationId;
        Value = value;
        Name = name;
    }
    public VariationOption(Guid id, string value, string name) : base(id)
    {
        Value = value;
        Name = name;
    }


    public Guid VariationId { get; private set; }
    public Variation Variation { get; private set; }

    public string Value { get; private set; }
    public string Name { get; private set; }

    public IEnumerable<ProductEntry> ProductEntries { get; private set; }
}
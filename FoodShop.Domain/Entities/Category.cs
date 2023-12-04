using FoodShop.Domain.Primitives;

namespace FoodShop.Domain.Entities;

public class Category : Entity
{
    public Category(Guid id,string name,int? parentId) : base(id)
    {
        Name = name;
        ParentId = parentId;
    }

    public int? ParentId { get; private set; }
    public string Name { get; private set; }

    public IEnumerable<Variation> Variations { get; private set; }
    
}

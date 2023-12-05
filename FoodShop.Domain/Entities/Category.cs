using FoodShop.Domain.Primitives;

namespace FoodShop.Domain.Entities;

public class Category : Entity
{
    public Category(Guid id,string name,Nullable<Guid> parentId) : base(id)
    {
        Name = name;
        ParentId = parentId;
    }
    
    public Nullable<Guid> ParentId { get; private set; }
    public Category ParentCategory { get; set; }
    public string Name { get; private set; }

    public IEnumerable<Variation> Variations { get; private set; }
    
}

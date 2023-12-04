using FoodShop.Domain.Primitives;

namespace FoodShop.Domain.Entities;

public class Variation : Entity
{
    public Variation(Guid id,string name,int categoryId) : base(id)
    {
        Name = name;
        CategoryId = categoryId;
    }

    public string Name { get; private set; }
    
    public int CategoryId { get; private set; }
    public Category Category { get; private set; }
}
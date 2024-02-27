using FoodShop.Domain.Primitives;

namespace FoodShop.Domain.Entities;

public class Product : Entity
{
    public Product(Guid id,string name,string description,Guid categoryId,string image) : base(id)
    {
        Name = name;
        Description = description;
        CategoryId = categoryId;
        Image = image;
    }

    public Guid SellerId { get; set; }
    public ApplicationSellerUser Seller { get; set; }

    public string Name { get; private set; }
    public string Description { get; private set; }
    
    public Category Category { get; private set; }    
    public Guid CategoryId { get; private set; }

    public string Image { get; private set; }
}
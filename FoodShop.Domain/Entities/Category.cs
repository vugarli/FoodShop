using FoodShop.Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace FoodShop.Domain.Entities;

public class Category : Entity
{
    public Category(Guid id,string name,Nullable<Guid> parentId,Nullable<Guid> BaseCategoryDiscriminatorId) : base(id)
    {
        Name = name;
        ParentId = parentId;
        this.BaseCategoryDiscriminatorId = BaseCategoryDiscriminatorId;
	}
	
	public Nullable<Guid> ParentId { get; private set; }
    public Category ParentCategory { get; set; }

    public string Name { get; private set; }

    public BaseCategoryDiscriminator? BaseCategoryDiscriminator { get; set; }
    public Guid? BaseCategoryDiscriminatorId { get; private set; }

    public IEnumerable<VariationCategory> VaritaionCategories { get; private set; }
    
}

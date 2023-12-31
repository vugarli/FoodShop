﻿using FoodShop.Domain.Primitives;

namespace FoodShop.Domain.Entities;

public class Variation : Entity
{
    public Variation(Guid id,string name) : base(id)
    {
        Name = name;
    }

    public string Name { get; private set; }

	public IEnumerable<VariationCategory> VaritaionCategories { get; private set; }
}
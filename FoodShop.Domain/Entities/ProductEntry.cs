﻿using FoodShop.Domain.Primitives;

namespace FoodShop.Domain.Entities;

public class ProductEntry : Entity
{
    public ProductEntry(Guid id,int productId,string sku,decimal price,string image,int quantity) : base(id)
    {
        ProductId = productId;
        Price = price;
        Image = image;
        Quantity = quantity;
        SKU = sku;
    }

    public int ProductId { get; private set; }
    public Product Product { get; private set; }

    public string SKU { get; private set; }
    public decimal Price { get; private set; }
    public string Image { get; private set; }
    public int Quantity { get; private set; }

    public IEnumerable<VariationOption> VariationOptions { get; private set; }
}
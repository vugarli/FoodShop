using AutoMapper;
using FoodShop.Application.ProductEntries;
using FoodShop.Application.ProductEntries.Commands.CreateProductEntry;
using FoodShop.Application.ProductEntries.Commands.UpdateProductEntry;
using FoodShop.Domain.Entities;

namespace FoodShop.Application.MappingProfiles;

public class ProductEntryProfile : Profile
{
    public ProductEntryProfile()
    {
        CreateMap<ProductEntry, ProductEntryDto>();
        CreateMap<ProductEntryDto, ProductEntry>();

        CreateMap<CreateProductEntryCommand, ProductEntry>()
            .ConstructUsing(c=>
                new ProductEntry(Guid.NewGuid(),c.ProductId,c.SKU,c.Price,c.Image,c.Quantity));
        
        CreateMap<UpdateProductEntryCommand,ProductEntry>()
            .ConstructUsing(c=>new ProductEntry(Guid.NewGuid(),c.ProductId,c.SKU,c.Price,c.Image,c.Quantity));
    }
}
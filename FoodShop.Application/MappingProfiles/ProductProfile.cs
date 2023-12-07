using AutoMapper;
using FoodShop.Application.Products;
using FoodShop.Application.Products.Commands.UpdateProduct;
using FoodShop.Domain.Entities;

namespace FoodShop.Application.MappingProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>();
        
        CreateMap<ProductDto, Product>();
        CreateMap<Product, Product>();
        CreateMap<UpdateProductCommand, Product>();
        
    }
}
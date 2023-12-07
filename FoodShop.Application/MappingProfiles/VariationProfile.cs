using System.Drawing;
using AutoMapper;
using FoodShop.Application.Variations;
using FoodShop.Application.Variations.Commands.CreateVariation;
using FoodShop.Application.Variations.Commands.UpdateVariation;
using FoodShop.Domain.Entities;

namespace FoodShop.Application.MappingProfiles;

public class VariationProfile : Profile
{
    public VariationProfile()
    {
        CreateMap<Variation, VariationDto>();
        CreateMap<VariationDto, Variation>();

        CreateMap<CreateVariationCommand, Variation>()
            .ConstructUsing(c=>new Variation(Guid.NewGuid(),c.Name,c.CategoryId));
        
        CreateMap<UpdateVariationCommand, Variation>()
            .ConstructUsing(c=>new Variation(Guid.NewGuid(),c.Name,c.CategoryId));
    }
}
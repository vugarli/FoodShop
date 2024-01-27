using AutoMapper;
using FoodShop.Application.VariationOptions;
using FoodShop.Application.VariationOptions.Commands.CreateVariationOption;
using FoodShop.Application.VariationOptions.Commands.UpdateVariationOption;
using FoodShop.Application.Variations;
using FoodShop.Application.Variations.Commands.CreateVariation;
using FoodShop.Application.Variations.Commands.UpdateVariation;
using FoodShop.Domain.Entities;

namespace FoodShop.Application.MappingProfiles;

public class VariationOptionProfile : Profile
{

    public VariationOptionProfile()
    {
        CreateMap<VariationOption, VariationOptionDto>()
            .ForMember(dto=>dto.VariationName,opt=>opt.MapFrom(vo=>vo.Variation.Name));


        CreateMap<VariationOptionDto, VariationOption>();

        CreateMap<CreateVariationOptionCommand, VariationOption>()
            .ConstructUsing(c=>new VariationOption(Guid.NewGuid(),c.VariationId,c.Value));
        
        CreateMap<UpdateVariationOptionCommand, VariationOption>()
            .ConstructUsing(c=>new VariationOption(Guid.NewGuid(),c.VariationId,c.Value));
    }
}
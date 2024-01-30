using AutoMapper;
using FoodShop.Application.BaseCategoryDiscriminators;
using FoodShop.Application.Categories;
using FoodShop.Application.Categories.Commands.CreateCategory;
using FoodShop.Application.Categories.Commands.UpdateCategory;
using FoodShop.Domain.Entities;
using Microsoft.Extensions.Logging.Abstractions;
using System.Linq;

namespace FoodShop.Application.MappingProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>()
            .ForMember(x => x.ParentName, a => a.MapFrom(c => c.ParentCategory.Name))
            .ForMember(x => x.BaseCategoryDiscriminatorName, a => a.MapFrom(c => c.BaseCategoryDiscriminator.Name));

        CreateMap<CategoryDto, Category>();

        CreateMap<CreateCategoryCommand, Category>()
            .ConstructUsing(c=>new Category(Guid.NewGuid(),c.Name,c.ParentId,c.BaseDiscriminatorId))
            .ForMember(c=>c.Variations,opt=>opt.Ignore())
            .AfterMap( (src,dest) => {
                if (src.Variations != null)
                {
                    foreach (var variation in src.Variations)
                    {
                        dest.AddVariation(variation);
                    }
                }
            });

        CreateMap<UpdateCategoryCommand, Category>()
            .ConstructUsing(c=>new Category(Guid.NewGuid(),c.Name,c.ParentId,c.BaseDiscriminatorId));


        // discriminator profile

        CreateMap<BaseCategoryDiscriminator, BaseCategoryDiscriminatorDto>();

    }
}
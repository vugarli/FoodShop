using AutoMapper;
using FoodShop.Application.Categories;
using FoodShop.Application.Categories.Commands.CreateCategory;
using FoodShop.Application.Categories.Commands.UpdateCategory;
using FoodShop.Domain.Entities;

namespace FoodShop.Application.MappingProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>().ForMember(x=>x.ParentName,a=>a.MapFrom(c=>c.ParentCategory.Name));

        CreateMap<CategoryDto, Category>();

        CreateMap<CreateCategoryCommand, Category>()
            .ConstructUsing(c=>new Category(Guid.NewGuid(),c.Name,c.ParentId,c.BaseDiscriminatorId));
        
        CreateMap<UpdateCategoryCommand, Category>()
            .ConstructUsing(c=>new Category(Guid.NewGuid(),c.Name,c.ParentId,c.BaseDiscriminatorId));
    }
}
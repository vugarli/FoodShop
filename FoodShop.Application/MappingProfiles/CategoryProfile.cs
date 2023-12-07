﻿using AutoMapper;
using FoodShop.Application.Categories;
using FoodShop.Application.Categories.Commands.CreateCategory;
using FoodShop.Application.Categories.Commands.UpdateCategory;
using FoodShop.Domain.Entities;

namespace FoodShop.Application.MappingProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();

        CreateMap<CreateCategoryCommand, Category>()
            .ConstructUsing(c=>new Category(Guid.NewGuid(),c.Name,c.ParentId));
        
        CreateMap<UpdateCategoryCommand, Category>()
            .ConstructUsing(c=>new Category(Guid.NewGuid(),c.Name,c.ParentId));
    }
}
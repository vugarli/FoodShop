﻿using FoodShop.Admin.WebApp.Client.Pages.Categories.ViewModels;
using FoodShop.Admin.WebApp.Client.Pages.Products.ViewModels;
using FoodShop.Admin.WebApp.Client.Pages.Variations.ViewModels;
using FoodShop.Application.Queries;

namespace FoodShop.Admin.WebApp.Client.Abstractions.Services
{
    public interface ICategoryService
    {
        public Task<bool> DeleteCategory(Guid id);
        public Task<bool> DeleteCategories(IEnumerable<Guid> ids);

        public Task<bool> CreateCategory(VM_CreateCategory category);
        public Task<bool> UpdateCategory(VM_UpdateCategory category);
        public Task<VM_Category> GetCategoryById(Guid id);
        public Task<IEnumerable<VM_Category>> GetCategories();
        public Task<IEnumerable<VM_Gender>> GetGenders();
        public Task<IEnumerable<VM_Category>> GetParentCategories();
        public Task<PaginatedQueryResult<VM_Category>> GetPaginatedCategories(int page, int per_page);
        public Task<bool> RemoveVariation(Guid categoryId,Guid variationId);
        public Task<IEnumerable<VM_Variation>> GetVariations(Guid categoryId);
        public Task<bool> AddVariation(Guid categoryId,Guid variationId);
    }
}

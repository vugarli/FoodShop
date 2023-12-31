﻿using FoodShop.Admin.WebApp.Client.Pages.Products.ViewModels;
using FoodShop.Application.Queries;

namespace FoodShop.Admin.WebApp.Client.Abstractions.Services
{
    public interface IProductService
    {
        public Task<bool> DeleteProduct(Guid id);
        public Task<bool> DeleteProducts(IEnumerable<Guid> ids);

        public Task<bool> CreateProduct(VM_CreateProduct product);
        public Task<bool> UpdateProduct(VM_UpdateProduct product);
        public Task<VM_Product> GetProductById(Guid id);
        public Task<IEnumerable<VM_Product>> GetProducts();
        public Task<PaginatedQueryResult<VM_Product>> GetPaginatedProducts(int page, int per_page);
    }
}

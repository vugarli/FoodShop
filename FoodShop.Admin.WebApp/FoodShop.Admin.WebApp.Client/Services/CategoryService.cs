using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using FoodShop.Admin.WebApp.Client.Pages.Categories.ViewModels;
using FoodShop.Admin.WebApp.Client.Pages.Products.ViewModels;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Pagination;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace FoodShop.Admin.WebApp.Client.Services
{
    public class CategoryService : ICategoryService
    {

        HttpClient client;
        public CategoryService(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("API");
        }

        public async Task<bool> CreateCategory(VM_CreateCategory category)
        {
            var result = await client.PostAsJsonAsync("/categories", category);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategories(IEnumerable<Guid> ids)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Delete, "/categories");
            message.Content =new StringContent(JsonSerializer.Serialize(ids), Encoding.UTF8, "application/json");
            var result = await client.SendAsync(message);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            var result = await client.DeleteAsync($"categories/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<VM_Category>> GetCategories()
        {
            var categories = await client.GetFromJsonAsync<IEnumerable<VM_Category>>("/categories");
            return categories;
        }

        public async Task<VM_Category> GetCategoryById(Guid id)
        {
            var category = await client.GetFromJsonAsync<VM_Category>($"/categories/{id}");
            return category;
        }

        public async Task<PaginatedResult<VM_Category>> GetPaginatedCategories(int page, int per_page)
        {
            var categories = await client.GetFromJsonAsync<PaginatedResult<VM_Category>>($"/categories?page={page}&per_page={per_page}");
            return categories;
        }

        public async Task<IEnumerable<VM_Category>> GetParentCategories()
        {
            var result = await client.GetFromJsonAsync<IEnumerable<VM_Category>>("/categories/parent");
            return result;
        }

        public async Task<bool> UpdateCategory(VM_UpdateCategory category)
        {
            var result = await client.PostAsJsonAsync("/categories",category);
            return result.IsSuccessStatusCode;
        }
    }
}

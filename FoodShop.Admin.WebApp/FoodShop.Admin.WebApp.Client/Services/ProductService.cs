using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using FoodShop.Admin.WebApp.Client.Pages.Products.ViewModels;
using FoodShop.Application.Pagination;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;

namespace FoodShop.Admin.WebApp.Client.Services
{
    public class ProductService : IProductService
    {
        HttpClient client;
        public ProductService(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("API");
        }

        public async Task<bool> CreateProduct(VM_CreateProduct product)
        {
            var res = await client.PostAsJsonAsync($"/products",product);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var res = await client.DeleteAsync($"/products/{id}");
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProducts(IEnumerable<Guid> ids)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "/products");
            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(ids), Encoding.UTF8, "application/json");
            var res = await client.SendAsync(request);
            return res.IsSuccessStatusCode;
        }

        public async Task<PaginatedResult<VM_Product>> GetPaginatedProducts(int page, int per_page)
        {
            var res = await client.GetFromJsonAsync<PaginatedResult<VM_Product>>($"/products?page={page}&per_page={per_page}");
            return res;
        }

        public async Task<VM_Product> GetProductById(Guid id)
        {
            var res = await client.GetFromJsonAsync<VM_Product>($"/products/{id}");
            return res;
        }

        public async Task<IEnumerable<VM_Product>> GetProducts()
        {
            var res = await client.GetFromJsonAsync<IEnumerable<VM_Product>>($"/products");
            return res;
        }

        public async Task<bool> UpdateProduct(VM_UpdateProduct product)
        {
            var res = await client.PutAsJsonAsync($"/products/{product.Id}",product);
            return res.IsSuccessStatusCode;
        }

        
    }
}

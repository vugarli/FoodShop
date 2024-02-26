using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using FoodShop.Admin.WebApp.Client.Pages.Products.ViewModels;
using FoodShop.Application.Queries;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using FoodShop.Common.Endpoints;
using SmartFormat;

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
            var res = await client.PostAsJsonAsync(ProductEndpoints.PostProductEndpoint,product);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var endpoint = Smart.Format(ProductEndpoints.DeleteProductByIdEndpoint,new {id});
            var res = await client.DeleteAsync(endpoint);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProducts(IEnumerable<Guid> ids)
        {
            var endpoint = Smart.Format(ProductEndpoints.DeleteProductsEndpoint);
            var request = new HttpRequestMessage(HttpMethod.Delete, endpoint);
            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(ids), Encoding.UTF8, "application/json");
            var res = await client.SendAsync(request);
            return res.IsSuccessStatusCode;
        }

        public async Task<PaginatedQueryResult<VM_Product>> GetPaginatedProducts(int page, int per_page)
        {
            var endpoint = Smart.Format(ProductEndpoints.PaginatedProductsEndpoint,new {page,per_page});
            var res = await client.GetFromJsonAsync<PaginatedQueryResult<VM_Product>>(endpoint);
            return res;
        }

        public async Task<VM_Product> GetProductById(Guid id)
        {
            var endpoint = Smart.Format(ProductEndpoints.GetProductByIdEndpoint, new {id});
            var res = await client.GetFromJsonAsync<VM_Product>(endpoint);
            return res;
        }

        public async Task<IEnumerable<VM_Product>> GetProducts()
        {
            var endpoint = ProductEndpoints.GetProductsEndpoint;
            var res = await client.GetFromJsonAsync<IEnumerable<VM_Product>>(endpoint);
            return res;
        }

        public async Task<bool> UpdateProduct(VM_UpdateProduct product)
        {
            var endpoint = Smart.Format(ProductEndpoints.UpdateProductEndpoint, new {id = product.Id });
            var res = await client.PutAsJsonAsync(endpoint,product);
            return res.IsSuccessStatusCode;
        }

        
    }
}

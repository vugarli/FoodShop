using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using FoodShop.Admin.WebApp.Client.Pages.ProductEntries.ViewModels;
using FoodShop.Admin.WebApp.Client.Pages.Products.ViewModels;
using FoodShop.Application.Queries;
using System.Net.Http.Json;
using System.Text;

namespace FoodShop.Admin.WebApp.Client.Services
{
    public class ProductEntryService : IProductEntryService
    {
        HttpClient client;
        public ProductEntryService(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("API");
        }

        public async Task<bool> CreateProductEntry(VM_CreateProductEntry model)
        {
            var res = await client.PostAsJsonAsync($"/productentries", model);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductEntries(IEnumerable<Guid> ids)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "/productentries");
            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(ids), Encoding.UTF8, "application/json");
            var res = await client.SendAsync(request);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductEntry(Guid id)
        {
            var res = await client.DeleteAsync($"/productentry/{id}");
            return res.IsSuccessStatusCode;
        }

        public async Task<PaginatedQueryResult<VM_ProductEntry>> GetPaginatedProductEntries(int page, int per_page)
        {
            var dto = await client.GetFromJsonAsync<PaginatedQueryResult<VM_ProductEntry>>($"/productentries?page={page}&per_page={per_page}");
            return dto;
        }

        public async Task<VM_ProductEntry> GetProductEntryById(Guid id)
        {
            var res = await client.GetFromJsonAsync<VM_ProductEntry>($"/productentries/{id}");
            return res;
        }

        public async Task<IEnumerable<VM_ProductEntry>> GetProductEntries()
        {
            var res = await client.GetFromJsonAsync<IEnumerable<VM_ProductEntry>>($"/productentries");
            return res;
        }

        public async Task<bool> UpdateProductEntry(VM_UpdateProductEntry model)
        {
            var res = await client.PutAsJsonAsync($"/productentries/{model.Id}", model);
            return res.IsSuccessStatusCode;
        }
    }
}

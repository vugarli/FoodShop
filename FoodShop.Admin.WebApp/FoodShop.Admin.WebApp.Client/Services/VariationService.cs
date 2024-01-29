using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using FoodShop.Admin.WebApp.Client.Pages.Variations.ViewModels;
using FoodShop.Application.Queries;
using System.Net.Http.Json;
using System.Text;

namespace FoodShop.Admin.WebApp.Client.Services
{
    public class VariationService : IVariationService
    {
        HttpClient httpClient;

        public VariationService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient("API");
        }


        public async Task<bool> CreateVariation(VM_CreateVariaiton model)
        {
            var result = await httpClient.PostAsJsonAsync("/variations",model);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteVariation(Guid id)
        {
            var result = await httpClient.DeleteAsync($"/variations/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteVariations(IEnumerable<Guid> ids)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "/variations");
            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(ids), Encoding.UTF8, "application/json");
            var res = await httpClient.SendAsync(request);
            return res.IsSuccessStatusCode;
        }

        public async Task<PaginatedQueryResult<VM_Variation>> GetPaginatedVariations(int page, int per_page)
        {
            var result = await httpClient.GetFromJsonAsync<PaginatedQueryResult<VM_Variation>>($"/variations?page={page}&per_page={per_page}");
            return result;
        }

        public async Task<VM_Variation> GetVariationById(Guid id)
        {
            var result = await httpClient.GetFromJsonAsync<VM_Variation>($"/variations/{id}");
            return result;
        }

        public async Task<IEnumerable<VM_Variation>> GetVariations()
        {
            var result = await httpClient.GetFromJsonAsync<QueryResult<VM_Variation>>("/variations");
            return result.Data;
        }

        public async Task<bool> UpdateVariation(VM_UpdateVariation model)
        {
            var result = await httpClient.PutAsJsonAsync($"/variations/{model.Id}",model);
            return result.IsSuccessStatusCode;
        }
    }
}

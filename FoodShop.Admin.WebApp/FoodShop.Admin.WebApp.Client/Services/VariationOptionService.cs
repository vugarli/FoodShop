using FoodShop.Admin.WebApp.Client.Abstractions.Services;

namespace FoodShop.Admin.WebApp.Client.Services
{
    public class VariationOptionService : IVariationOptionService
    {
        HttpClient _httpClient;
        public VariationOptionService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<bool> DeleteVariatonOptionAsync(Guid Id)
        {
            var result = await _httpClient.DeleteAsync($"/variationoptions/{Id}");
            return result.IsSuccessStatusCode;
        }
    }
}

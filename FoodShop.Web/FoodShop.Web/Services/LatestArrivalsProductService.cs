
using FoodShop.Web.Abstractions.Services;
using FoodShop.Web.ViewModels.Products;

namespace FoodShop.Web.Services
{
    public class LatestArrivalsProductService : ILatesArrivalsProductServices
    {
        HttpClient client;

        public LatestArrivalsProductService(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("API");
        }

        public async Task<IEnumerable<ProductItemViewModel>> GetLatestArrivals()
        {
            var products = (await client.GetFromJsonAsync<PaginatedResult<ProductItemViewModel>>("/products?page=1&per_page=20")).Data;
            return products;
        }
    }
}

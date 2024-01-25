
using FoodShop.Web.Abstractions.Services;
using FoodShop.Web.ViewModels.Products;
using System.Net.Http.Json;

namespace FoodShop.Web.Client.Services
{
    public class LatestArrivalsProductService : ILatesArrivalsProductServices
    {
        HttpClient client;
        public const int GroupSize = 4;

        public LatestArrivalsProductService(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("API");
        }


        public async Task<IEnumerable<IEnumerable<ProductItemViewModel>>> GetLatestArrivalsGroups()
        {
            var products = (await client.GetFromJsonAsync<PaginatedResult<ProductItemViewModel>>("/ProductEntries?LatestProducts=true")).Data.ToList();
            var groups = new List<List<ProductItemViewModel>>();

            var groupSize = (int)Math.Ceiling(products.Count()*1.0 / GroupSize);

            foreach (var group in Enumerable.Range(1,groupSize))
            {
                var items = products.Skip((group-1)*GroupSize).Take(GroupSize).ToList();
                groups.Add(items);
            }

            return groups;
        }


    }
}


using FoodShop.Web.Abstractions.Services;
using FoodShop.Web.ViewModels.Products;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace FoodShop.Web.Client.Services
{
    public class LatestArrivalsProductService : ILatesArrivalsProductServices
    {
        HttpClient client;
        public const int GroupSize = 4;

        public AuthenticationStateProvider A { get; }

        public LatestArrivalsProductService(IHttpClientFactory httpClientFactory, AuthenticationStateProvider a)
        {
            client = httpClientFactory.CreateClient("API");
            A = a;
        }
        

        public async Task<IEnumerable<IEnumerable<ProductItemViewModel>>> GetLatestArrivalsGroups()
        {

            var aa = await A.GetAuthenticationStateAsync();
            var products = (await client.GetFromJsonAsync<PaginatedResult<ProductItemViewModel>>("/api/ProductEntries?LatestProducts=true")).Data.ToList();
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

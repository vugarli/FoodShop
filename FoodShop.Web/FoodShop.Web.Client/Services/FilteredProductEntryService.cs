using FoodShop.Web.Client.Abstractions.Services;
using FoodShop.Web.ViewModels.Products;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;

namespace FoodShop.Web.Client.Services
{
    public class FilteredProductEntryService : IFilteredProductEntryService
    {

        HttpClient client;

        public FilteredProductEntryService(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("API");
        }

        
        public async Task<IEnumerable<ProductItemViewModel>> GetFilteredProductEntries(Dictionary<string,string> queryParams)
        {
            var uri = "/productentries";
            uri = QueryHelpers.AddQueryString(uri,queryParams);

            var result = (await client.GetFromJsonAsync<PaginatedResult<ProductItemViewModel>>(uri)).Data;

            return result;
        }

        
    }
}

using FoodShop.Application.Products;
using Microsoft.AspNetCore.Components;

namespace FoodShop.Admin.WebApp.Components.Pages.Products
{
    public class ProductsBase : ComponentBase
    {
        public IEnumerable<ProductDto> Products { get; set; }

        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }



        protected override async Task OnInitializedAsync()
        {
            var client = ClientFactory.CreateClient("API");
            Products = await client.GetFromJsonAsync<IEnumerable<ProductDto>>("/products");

        }
    }
}

using MudBlazor;
using MudBlazor.Services;

namespace FoodShop.Admin.WebApp.Client.Extensions
{
    public static class CommonServiceExtensions
    {

        public static IServiceCollection RegisterCommonServices(this IServiceCollection services)
        {
            services.AddMudServices();

            return services;
        }
    }
}

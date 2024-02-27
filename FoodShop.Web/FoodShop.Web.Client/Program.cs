using FoodShop.Web.Abstractions.Services;
using FoodShop.Web.Client.Abstractions.Services;
using FoodShop.Web.Client.Services;
using FoodShop.Web.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MudExtensions.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient("API", (sp, cl) =>
{
    cl.BaseAddress = new Uri("http://localhost:7222");
}).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddMudServices();
builder.Services.AddMudExtensions();

builder.Services.AddScoped<IDiscriminatorGroupsService, DiscriminatorGroupsService>();
builder.Services.AddScoped<IFilteredProductEntryService, FilteredProductEntryService>();
builder.Services.AddScoped<ILatesArrivalsProductServices, LatestArrivalsProductService>();

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
});


await builder.Build().RunAsync();

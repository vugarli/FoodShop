using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using FoodShop.Admin.WebApp.Client.Extensions;
using FoodShop.Admin.WebApp.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.RegisterCommonServices();

builder.Services.AddHttpClient("API", (sp, cl) =>
{
    cl.BaseAddress = new Uri("http://localhost:5294");
});
//builder.Services.AddHttpClient("API",
//    client => client.BaseAddress = new Uri("https://localhost:7222/"));


builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductEntryService, ProductEntryService>();

builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddScoped<IFileUploadService,FileUploadService>();


await builder.Build().RunAsync();

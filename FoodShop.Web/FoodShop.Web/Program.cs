
using FoodShop.Web.Abstractions.Services;
using FoodShop.Web.Client.Abstractions.Services;
using FoodShop.Web.Client.Pages;
using FoodShop.Web.Client.Services;
using FoodShop.Web.Components;
using FoodShop.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MudBlazor.Services;
using MudExtensions.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient("API", (sp, cl) =>
{
    cl.BaseAddress = new Uri("http://localhost:5294");
});


builder.Services.AddScoped<ILatesArrivalsProductServices, LatestArrivalsProductService>();
builder.Services.AddScoped<IDiscriminatorGroupsService, DiscriminatorGroupsService>();
builder.Services.AddScoped<IFilteredProductEntryService, FilteredProductEntryService>();

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
});

builder.Services.AddAuthentication(options=>options.DefaultAuthenticateScheme= CookieAuthenticationDefaults.AuthenticationScheme);

builder.Services.AddMudServices();
builder.Services.AddMudExtensions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();

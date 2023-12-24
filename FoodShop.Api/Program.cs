using FoodShop.Api.Configuration;
using FoodShop.Api.Middleware;
using FoodShop.Api.Seeding;
using FoodShop.Presentation.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.InstallInfrastructureServices(builder.Configuration);
builder.Services.InstallApplicationServices(builder.Configuration);
builder.Services.InstallDomainServices(builder.Configuration);
builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddCors();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
   // app.SeedDb();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.MapProducts().WithOpenApi();
app.MapCategories().WithOpenApi();
app.MapVariations().WithOpenApi();
app.MapVariationOptions().WithOpenApi();
app.MapProductEntries().WithOpenApi();

app.UseCors(options=>options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();

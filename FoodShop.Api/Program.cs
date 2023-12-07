using FoodShop.Api.Configuration;
using FoodShop.Api.Middleware;
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



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.MapProducts().WithOpenApi();
app.MapCategories().WithOpenApi();


app.Run();

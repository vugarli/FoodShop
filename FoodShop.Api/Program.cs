using FoodShop.Api.Middleware;
using FoodShop.Presentation.Endpoints;
using FoodShop.Application;
using FoodShop.Infrastructure;
using FoodShop.Api.Filters;
using FoodShop.Api.Seeding;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InstallInfrastructureServices(builder.Configuration);
builder.Services.InstallApplicationServices();

builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddCors();

builder.Services.AddControllers(options=>
{
    options.Filters.Add(new PaginationActionFilter());
    options.Filters.Add(new ExceptionFilter());
    options.SuppressAsyncSuffixInActionNames = false;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.SeedDb();
}

app.UseHttpsRedirection();
//app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();


app.UseCors(x => x
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .SetIsOriginAllowed(origin => true)
                   .AllowCredentials());
app.Run();

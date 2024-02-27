using FoodShop.Api.Middleware;
using FoodShop.Presentation.Endpoints;
using FoodShop.Application;
using FoodShop.Infrastructure;
using FoodShop.Api.Filters;
using FoodShop.Api.Seeding;
using FoodShop.Api;
using FoodShop.Infrastructure.IdentityRelated;
using FluentAssertions.Common;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodShop", Version = "v1.0.0" });

    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "Using the Authorization header with the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securitySchema);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
              { securitySchema, new[] { "Bearer" } }
          });
});

builder.Services.InstallInfrastructureServices(builder.Configuration);
builder.Services.InstallApplicationServices();

builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddCors();

builder.Services.SetupIdentity(builder.Configuration);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.UseCors(x => x
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .SetIsOriginAllowed(origin => true)
                   .AllowCredentials());
app.Run();

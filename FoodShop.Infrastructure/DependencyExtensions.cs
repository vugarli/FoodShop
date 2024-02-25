using FoodShop.Application.Abstractions;
using FoodShop.Domain.Abstractions;
using FoodShop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodShop.Infrastructure
{
    public static class DependencyExtensions
    {
        public static IServiceCollection InstallInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IVariationRepository, VariationRepository>();
            services.AddScoped<IVariationOptionRepository, VariationOptionRepository>();
            services.AddScoped<IProductEntryRepository, ProductEntryRepository>();
            services.AddScoped<IBaseCategoryDiscriminatorRepository, BaseCategoryDiscriminatorRepository>();

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(config["ConnectionString"],
                    o => o.MigrationsAssembly("FoodShop.Api")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();



            return services;
        }
    }
}

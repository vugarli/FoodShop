﻿using FoodShop.Application.Abstractions;
using FoodShop.Domain.Abstractions;
using FoodShop.Infrastructure;
using FoodShop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodShop.Api.Configuration;

public static class InfrastructureServices
{
    public static IServiceCollection InstallInfrastructureServices(this IServiceCollection services, ConfigurationManager config)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(config["ConnectionString"],
                o => o.MigrationsAssembly("FoodShop.Api")));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}
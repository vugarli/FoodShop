using FluentAssertions.Common;
using FoodShop.Infrastructure;
using FoodShop.Infrastructure.IdentityRelated;
using Microsoft.AspNetCore.Identity;
using System;

namespace FoodShop.Api
{
    public static class IdentitySetupExtensions
    {


        public static IServiceCollection SetupIdentity(this IServiceCollection services)
        {

            services.AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddIdentityCookies();

            services.AddAuthorizationBuilder();

            services.AddIdentityCore<ApplicationIdentityUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();

            return services;
        }



    }
}

using FluentAssertions.Common;
using FoodShop.Infrastructure;
using FoodShop.Infrastructure.IdentityRelated;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace FoodShop.Api
{
    public static class IdentitySetupExtensions
    {


        public static IServiceCollection SetupIdentity
            (
            this IServiceCollection services,
            IConfiguration configuration
            )
        {

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //{
            //    options.Authority = "https://dev-hiywqongfvfrqbr0.us.auth0.com/";
            //    options.Audience = "https://foodshop.com";
            //});

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, c =>
            {
                c.Authority = $"https://{configuration["Auth0:Domain"]}";
                c.TokenValidationParameters = new       Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidAudience = configuration["Auth0:Audience"],
                    ValidIssuer = $"https://{configuration["Auth0:Domain"]}"
                };
            });

            return services;
        }



    }
}

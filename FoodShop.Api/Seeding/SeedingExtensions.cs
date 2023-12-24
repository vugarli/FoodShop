using FoodShop.Infrastructure;
using FoodShop.Infrastructure.TestData;
using Microsoft.AspNetCore.Builder;

namespace FoodShop.Api.Seeding
{
	
		public static class SeedingExtensions
		{
			public static IApplicationBuilder SeedDb(this IApplicationBuilder app)
			{

			using var scope = app.ApplicationServices.CreateScope();

			var services = scope.ServiceProvider;
			try
			{
				var context = services.GetRequiredService<ApplicationDbContext>();
				DatabaseSeeder.Seed(context);
			}
			catch (Exception ex)
			{

			}

			return app;
		}
		}
}

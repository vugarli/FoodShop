using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace FoodShop.Infrastructure.DbContextConfig
{
    internal class DbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            return new ApplicationDbContext(configuration);
        }
    }
}

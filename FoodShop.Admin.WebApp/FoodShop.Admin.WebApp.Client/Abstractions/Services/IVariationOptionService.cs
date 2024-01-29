namespace FoodShop.Admin.WebApp.Client.Abstractions.Services
{
    public interface IVariationOptionService
    {

        public Task<bool> DeleteVariatonOptionAsync(Guid Id);

    }
}

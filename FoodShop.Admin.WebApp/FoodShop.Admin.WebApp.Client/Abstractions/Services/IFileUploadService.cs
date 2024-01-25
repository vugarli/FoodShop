using Microsoft.AspNetCore.Components.Forms;

namespace FoodShop.Admin.WebApp.Client.Abstractions.Services
{
    public interface IFileUploadService
    {
        public Task<string> UploadFileAndProvideNameAsync(IBrowserFile e);
    }
}

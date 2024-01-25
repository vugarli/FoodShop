using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Services.Abstract
{
    public interface IPresignedUploadUrlGeneratorService
    {
        public Task<string> GenerateUrlAsync(string fileName, string bucketName);
    }
}

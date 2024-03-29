﻿using FoodShop.Admin.WebApp.Client.Abstractions.Services;
using Microsoft.AspNetCore.Components.Forms;

namespace FoodShop.Admin.WebApp.Client.Services
{
    public class FileUploadService : IFileUploadService
    {
        HttpClient client;
        HttpClient uploadClient;
        public FileUploadService(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("API");
            uploadClient = httpClientFactory.CreateClient();   
        }

        public async Task<string> UploadFileAndProvideNameAsync(IBrowserFile e)
        {
            var newFileName = Guid.NewGuid().ToString()+e.Name;
            var url = await client.GetStringAsync($"/fileupload/photos/{newFileName}");
            url = url.Replace("https", "http"); // certificate problem

            long maxFileSize = 1024L * 1024L * 1024L * 2L;

            using (MemoryStream ms = new MemoryStream())
            { 
                await e.OpenReadStream(maxFileSize).CopyToAsync(ms);
                using (ByteArrayContent fileContent = new ByteArrayContent(ms.ToArray()))
                {
                    HttpResponseMessage response = await uploadClient.PutAsync(url, fileContent);
                }
            }
            return newFileName;
        }
    }
}

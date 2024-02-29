using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Http;
using Auth0.ManagementApi.Models;
using RestSharp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Newtonsoft.Json;

namespace FoodShop.Infrastructure.Services
{
    public interface IManagementApiTokenService
    {
        public Task<string> AcquireTokenAsync();
    }

    public record ManagementApiTokenResponse(string access_token);

    public class ManagementApiTokenService : IManagementApiTokenService
    {
        public IConfiguration _configuration { get; }

        public ManagementApiTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<string> AcquireTokenAsync()
        {
            var domain = _configuration.GetSection("Auth0")["Domain"];
            var clientId = _configuration.GetSection("Auth0")["ManageClientId"];
            var clientSecret = _configuration.GetSection("Auth0")["ManageClienSecret"];
            var audience = _configuration.GetSection("Auth0")["ManageAudience"];

            var client = new RestClient($"https://dev-hiywqongfvfrqbr0.us.auth0.com/oauth/token");

            var request = new RestRequest();
            request.Method = Method.Post;

            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            
            request.AddParameter(
                "application/x-www-form-urlencoded",
                $"grant_type=client_credentials&client_id={clientId}&client_secret={clientSecret}&audience={audience}",
                ParameterType.RequestBody);
            
            
            var response = await client.ExecuteAsync(request);
            
            var responseobj = JsonConvert.DeserializeObject<ManagementApiTokenResponse>(response.Content);

            return responseobj.access_token;
        }
    }
}

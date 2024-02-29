using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using FoodShop.Application.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Infrastructure.Services
{
    public class UserService : IUserService
    {
        IManagementApiClient _managementApiClient;
        private readonly IManagementApiTokenService _tokenService;
        private readonly IConfiguration _configuration;

        public UserService
            (
            IManagementApiTokenService tokenService,
            IConfiguration configuration
            )
        {
            _tokenService = tokenService;
            _configuration = configuration;
        }

        public async Task CreateUserAsync(CreateUserRequest request)
        {
            string token = await _tokenService.AcquireTokenAsync();

            string managementApiUrl = _configuration.GetSection("Auth0")["ManageAPIUrl"];
            string clientId = _configuration.GetSection("Auth0")["ManageClientId"];

            _managementApiClient = new ManagementApiClient(token, new Uri(managementApiUrl));

            var connection = await _managementApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "auth0",
                EnabledClients = new[] { clientId }
            });

            var user = await _managementApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = connection.Name,
                Email = request.Email,
                EmailVerified = true,
                Password = request.Password,
                UserMetadata = new {type=request.UserType}
            }) ;

        }
    }
}

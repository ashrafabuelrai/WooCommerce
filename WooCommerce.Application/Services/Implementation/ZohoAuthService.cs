using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using WooCommerce.Application.Services.Interfaces;
using WooCommerce.Infrastructure.Configurations;

namespace WooCommerce.Application.Services.Implementation
{
    public class ZohoAuthService : IZohoAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ZohoOptions _options;

        public ZohoAuthService(
            HttpClient httpClient,
            IOptions<ZohoOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            var values = new Dictionary<string, string>
        {
            { "refresh_token", _options.RefreshToken },
            { "client_id", _options.ClientId },
            { "client_secret", _options.ClientSecret },
            { "grant_type", "refresh_token" }
        };

            Console.WriteLine(_options.AccountsUrl);
            var response = await _httpClient.PostAsync(
                $"{_options.AccountsUrl}/oauth/v2/token",
                new FormUrlEncodedContent(values));

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(json);

            return document.RootElement
                           .GetProperty("access_token")
                           .GetString()!;
        }
    }
}

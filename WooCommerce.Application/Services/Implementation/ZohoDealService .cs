using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WooCommerce.Application.DTOs;
using WooCommerce.Application.Services.Interfaces;
using WooCommerce.Infrastructure.Configurations;

namespace WooCommerce.Application.Services.Implementation
{
    public class ZohoDealService : IZohoDealService
    {
        private readonly HttpClient _httpClient;
        private readonly IZohoAuthService _authService;
        private readonly ZohoOptions _options;

        public ZohoDealService(
            HttpClient httpClient,
            IZohoAuthService authService,
            IOptions<ZohoOptions> options)
        {
            _httpClient = httpClient;
            _authService = authService;
            _options = options.Value;
        }

        public async Task<string> CreateDealAsync(DealDto deal)
        {
            var token = await _authService.GetAccessTokenAsync();

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Zoho-oauthtoken", token);

            var body = new
            {
                data = new[]
                {
            new
            {
                Deal_Name = deal.DealName,
                Stage = deal.Stage,
                Amount = deal.Amount,

                Contact_Name = new
                {
                    id = deal.ContactId
                }
            }
        }
            };

            var json = JsonSerializer.Serialize(body);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");
            Console.WriteLine($"{_options.ApiUrl}/Deals");
            var response = await _httpClient.PostAsync(
                $"{_options.ApiUrl}/Deals",
                content);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(responseContent);

            var dealId = document
                .RootElement
                .GetProperty("data")[0]
                .GetProperty("details")
                .GetProperty("id")
                .GetString();

            return dealId!;
        }
    }
}

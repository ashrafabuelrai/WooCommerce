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
    public class ZohoContactService : IZohoContactService
    {
        private readonly HttpClient _httpClient;
        private readonly IZohoAuthService _authService;
        private readonly ZohoOptions _options;

        public ZohoContactService(
            HttpClient httpClient,
            IZohoAuthService authService,
            IOptions<ZohoOptions> options)
        {
            _httpClient = httpClient;
            _authService = authService;
            _options = options.Value;
        }
        public async Task<string?> GetContactByEmailAsync(string email)
        {
            var token = await _authService.GetAccessTokenAsync();

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Zoho-oauthtoken", token);

            var response = await _httpClient.GetAsync(
                $"{_options.ApiUrl}/Contacts/search?email={Uri.EscapeDataString(email)}");

            // Contact غير موجود
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent ||
                response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(responseContent);

            var contactId = document
                .RootElement
                .GetProperty("data")[0]
                .GetProperty("id")
                .GetString();

            return contactId;
        }

        public async Task<string> CreateContactAsync(ContactDto contact)
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
                    First_Name = contact.FirstName,
                    Last_Name = contact.LastName,
                    Email = contact.Email,
                    Phone = contact.Phone
                }
            }
            };

            var json = JsonSerializer.Serialize(body);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync(
                $"{_options.ApiUrl}/Contacts",
                content);

            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(responseContent);

            var contactId = document
                .RootElement
                .GetProperty("data")[0]
                .GetProperty("details")
                .GetProperty("id")
                .GetString();

            return contactId!;
        }
    }
}

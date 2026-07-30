using System;
using System.Collections.Generic;
using System.Text;

namespace WooCommerce.Infrastructure.Configurations
{
    public class ZohoOptions
    {
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public string AccountsUrl { get; set; } = string.Empty;
        public string ApiUrl { get; set; } = string.Empty;
    }
}

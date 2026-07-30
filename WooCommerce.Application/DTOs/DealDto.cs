using System;
using System.Collections.Generic;
using System.Text;

namespace WooCommerce.Application.DTOs
{
    public class DealDto
    {
        public string DealName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Stage { get; set; } = "Qualification";
        public string ContactId { get; set; } = string.Empty;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WooCommerce.Application.DTOs
{
    public class OrderDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public string DealName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}

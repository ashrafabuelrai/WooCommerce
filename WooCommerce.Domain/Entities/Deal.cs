using System;
using System.Collections.Generic;
using System.Text;

namespace WooCommerce.Domain.Entities
{
    public class Deal
    {
        public string DealName { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public string Stage { get; set; } = "Qualification";
    }
}

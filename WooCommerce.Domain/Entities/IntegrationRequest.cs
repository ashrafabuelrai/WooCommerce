using System;
using System.Collections.Generic;
using System.Text;

namespace WooCommerce.Domain.Entities
{
    public class IntegrationRequest
    {
        public Customer Customer { get; set; } = new();

        public Deal Deal { get; set; } = new();
    }
}

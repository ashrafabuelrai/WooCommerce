using System;
using System.Collections.Generic;
using System.Text;

namespace WooCommerce.Domain.Entities;


public class Customer
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;
}

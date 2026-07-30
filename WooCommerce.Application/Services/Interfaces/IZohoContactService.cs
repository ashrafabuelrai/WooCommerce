using System;
using System.Collections.Generic;
using System.Text;
using WooCommerce.Application.DTOs;

namespace WooCommerce.Application.Services.Interfaces
{
    public interface IZohoContactService
    {
        Task<string> CreateContactAsync(ContactDto contact);

        Task<string?> GetContactByEmailAsync(string email);

    }
}

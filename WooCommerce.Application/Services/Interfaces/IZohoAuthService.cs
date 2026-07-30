using System;
using System.Collections.Generic;
using System.Text;

namespace WooCommerce.Application.Services.Interfaces
{
    public interface IZohoAuthService
    {
        Task<string> GetAccessTokenAsync();
    }
}

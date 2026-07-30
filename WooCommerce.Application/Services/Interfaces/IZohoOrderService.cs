using System;
using System.Collections.Generic;
using System.Text;
using WooCommerce.Application.DTOs;

namespace WooCommerce.Application.Services.Interfaces
{
    public interface IZohoOrderService
    {
        Task<string> CreateOrderAsync(OrderDto dto);

    }
}

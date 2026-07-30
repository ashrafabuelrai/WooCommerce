using System;
using System.Collections.Generic;
using System.Text;
using WooCommerce.Application.DTOs;

namespace WooCommerce.Application.Services.Interfaces
{
    public interface IZohoDealService
    {
        Task<string> CreateDealAsync(DealDto deal);
    }
}

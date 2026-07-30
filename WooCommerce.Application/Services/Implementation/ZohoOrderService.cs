using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using WooCommerce.Application.DTOs;
using WooCommerce.Application.Services.Interfaces;
using WooCommerce.Infrastructure.Configurations;

namespace WooCommerce.Application.Services.Implementation
{
    public class ZohoOrderService : IZohoOrderService
    {
        
        private readonly IZohoContactService _contactService;
        private readonly IZohoDealService _dealService;

        public ZohoOrderService(
           
            IZohoContactService contactService,
            IZohoDealService dealService)
        {
            
            _contactService = contactService;
            _dealService = dealService;
        }

        public async Task<string> CreateOrderAsync(OrderDto dto)
        {
            var contactId = await _contactService.GetContactByEmailAsync(dto.Email);

            if (contactId == null)
            {
                contactId = await _contactService.CreateContactAsync(
                    new ContactDto
                    {
                        FirstName = dto.FirstName,
                        LastName = dto.LastName,
                        Email = dto.Email,
                        Phone = dto.Phone
                    });
            }

            var dealId = await _dealService.CreateDealAsync(
                new DealDto
                {
                    DealName = dto.DealName,
                    Amount = dto.Amount,
                    ContactId = contactId
                });

            return "Order Created Successfully";
                
        }

        
    }
    
}

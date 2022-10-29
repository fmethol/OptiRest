using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptiRest.Models.Dtos;

namespace OptiRest.Service.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> AddOrder(OrderDto orderDto);
    }
}

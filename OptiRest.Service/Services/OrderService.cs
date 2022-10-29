using Microsoft.AspNetCore.Mvc;
using OptiRest.Data.Context;
using OptiRest.Data.Models;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _db;

        public OrderService(AppDbContext db)
        {
            _db = db;
        }


        public async Task<OrderDto> AddOrder(OrderDto orderDto)
        {
            int tableServiceId = orderDto.TableServiceId;

            orderDto.OrderDetails.ForEach(orderDetail =>
            {
                TableService2Item tableService2Item = new TableService2Item
                {
                    TableServiceId = tableServiceId,
                    ItemId = orderDetail.ItemId,
                    Quantity = orderDetail.Quantity,
                    Price = _db.Items.FirstOrDefault(i => i.Id == orderDetail.ItemId).Price,
                    ItemStateId = 1,
                    OrderTime = DateTime.Now
                };

                 _db.Add(tableService2Item);
                 _db.SaveChanges();
            });

            return orderDto;
        }
    }
}

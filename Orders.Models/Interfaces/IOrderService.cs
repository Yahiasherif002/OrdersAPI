using Orders.Domain.DTOs;
using Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Interfaces
{
    public interface IOrderService
    {
        public  Task<Order> CreateOrderAsync(CreateOrderDto orderDto);
    }
}

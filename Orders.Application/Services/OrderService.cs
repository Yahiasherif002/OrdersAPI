using Orders.Domain.DTOs;
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Services
{
    public class OrderService:IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrderAsync(CreateOrderDto orderDto)
        {
            var customer = await _unitOfWork.Customers.GetById(orderDto.CustomerId);
            if (customer == null)
            {
                throw new Exception("Customer Not Found");
            }
            var order = new Order
            {
                CustomerId = orderDto.CustomerId,
                OrderId = Guid.NewGuid(),
                OrderDate = DateTime.UtcNow,
                OrderDetails = orderDto.orderDetails.Select(d => new OrderDetail
                {
                    OrderDetailId = Guid.NewGuid(),
                    ProductName = d.ProductName,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice
                }).ToList()


            };
            order.TotalAmount = orderDto.orderDetails.Sum(d => d.Quantity * d.UnitPrice);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var year = DateTime.UtcNow.Year;
                var count = await _unitOfWork.Orders.GetOrderCountForYearAsync(year) + 1;
                order.OrderNumber = $"Order_{year}_{count}";
                await _unitOfWork.Orders.AddAsync(order);
                await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitTransactionAsync();
                return order;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }

        }



    }
}

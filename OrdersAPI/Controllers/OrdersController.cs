using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Orders.Domain.DTOs;
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;
using Orders.Infrastructure;

namespace OrdersAPI.Controllers
{
   
    public class OrdersController : CustomControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;

        public OrdersController(IUnitOfWork unitOfWork, IOrderService orderService)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            var orders= await _unitOfWork.Orders.GetAllAsync();
            var orderDtos = orders.Select(order => new OrderDTO
            {
                OrderNumber = order.OrderNumber,
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount
            });
            return Ok(orderDtos);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            var order = await _unitOfWork.Orders.GetById(id);

            if (order == null) return NotFound();

            var orderDTO = new OrderDTO
            {
                OrderId = order.OrderId,
                OrderNumber = order.OrderNumber,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount
            };

            return Ok(orderDTO);
        }

       
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(CreateOrderDto orderDto)
        {
            if (orderDto == null || orderDto.orderDetails.Count == 0) return BadRequest("Invalid Order Data");
            try
            {
                var order = await _orderService.CreateOrderAsync(orderDto);

                return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message });
            }

        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var order = await _unitOfWork.Orders.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            _unitOfWork.Orders.Delete(order);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        
    }
}

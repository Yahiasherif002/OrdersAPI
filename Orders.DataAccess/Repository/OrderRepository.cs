using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orders.Domain.Interfaces;
using System.Threading.Tasks;
using Orders.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Orders.Infrastructure.Repository
{
    internal class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context): base(context) 
        {
            _context = context;
        }

        public async Task<int> GetOrderCountForYearAsync(int year)
        {
            return await _context.Orders.CountAsync(o=>o.OrderDate.Year==year);
        }
    }
}

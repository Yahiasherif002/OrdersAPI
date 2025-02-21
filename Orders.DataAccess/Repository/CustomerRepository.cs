using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Repository
{
    internal class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer?> GetCustomerWithOrdersAsync(Guid id)
        {
            return await _context.Customers
                           .Include(c => c.Orders)  // Eager load Orders
                           .FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        async Task<Customer> ICustomerRepository.GetCustomerWithOrdersAsync(Guid id)
        {
            return await GetCustomerWithOrdersAsync(id) ?? throw new InvalidOperationException("Customer not found");
        }
    }
}

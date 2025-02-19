using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;

namespace Orders.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Orders = new Repository<Order>(context);
            Customers = new Repository<Customer>(context);
            OrderDetails = new Repository<OrderDetail>(context);
        }

        public IRepository<Order> Orders { get; }

        public IRepository<Customer> Customers { get; }

        public IRepository<OrderDetail> OrderDetails { get; }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    }
        
}

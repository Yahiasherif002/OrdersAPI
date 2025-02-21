using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;

namespace Orders.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Orders = new OrderRepository(context);
            Customers = new CustomerRepository(context);
            OrderDetails = new Repository<OrderDetail>(context);
        }

        public IOrderRepository Orders { get; }

        public ICustomerRepository Customers { get; }

        public IRepository<OrderDetail> OrderDetails { get; }

        public async Task BeginTransactionAsync() => _transaction= await _context.Database.BeginTransactionAsync();
        

        public async Task CommitTransactionAsync()
        {
            if(_transaction !=null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;

            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;

            }
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    }
        
}

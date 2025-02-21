using Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; }
        ICustomerRepository Customers { get; }

        IRepository<OrderDetail> OrderDetails { get; }
        Task<int> SaveAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();

    }
}

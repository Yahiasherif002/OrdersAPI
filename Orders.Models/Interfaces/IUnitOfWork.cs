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
        IRepository<Order> Orders { get; }
        IRepository<Customer> Customers { get; }

        IRepository<OrderDetail> OrderDetails { get; }
        Task<int> SaveAsync();

    }
}

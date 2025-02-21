using Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Interfaces
{
    public interface IOrderRepository:IRepository<Order>
    {
        Task<int> GetOrderCountForYearAsync(int year);

    }
}

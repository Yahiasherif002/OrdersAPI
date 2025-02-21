using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.DTOs
{
    public class OrderDetailDto
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }

        public Decimal UnitPrice{ get; set; }
    }
}

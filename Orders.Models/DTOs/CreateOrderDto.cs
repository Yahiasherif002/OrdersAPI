using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Orders.Domain.DTOs
{
    public class CreateOrderDto
    {
        public Guid CustomerId { get; set; }
        public List<OrderDetailDto> orderDetails { get; set; } = new List<OrderDetailDto>();
    }
}

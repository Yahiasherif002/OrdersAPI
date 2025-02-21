using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Orders.Domain.Entities
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailId { get; set; } = Guid.NewGuid();

        public Guid OrderId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        [Required, Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required, Range(0.01, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        [ForeignKey("OrderId")]
        [ValidateNever]
        [JsonIgnore]
        public Order Order { get; set; } = null!;
    }
}

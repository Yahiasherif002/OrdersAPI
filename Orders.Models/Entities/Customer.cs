using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; } = Guid.NewGuid();
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, Phone]
        public string Phone { get; set; } = string.Empty;
        [Required, MaxLength(150)]
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

using System.ComponentModel.DataAnnotations;

namespace Orders.Domain.Entities
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; } = Guid.NewGuid();
        [Required]
        public string OrderNumber { get; set; } = string.Empty;

        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        public decimal TotalAmount { get; set; }

        public Customer Customer { get; set; } = null!;
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();



    }
}

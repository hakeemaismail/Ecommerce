using DAL.Models.Enums;

namespace DAL.Models
{
    public class Order : BaseEntity
    {
        public DateTime OrderDateTime { get; set; } = DateTime.Now;
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public string? ShippingAddress { get; set; }
        public float? TotalAmount { get; set; }

        //Relationships
        public ShoppingCart? ShoppingCart { get; set; }
        public int? CartID { get; set; }
        public Payment? Payment { get; set; }
        public Customer? Customer { get; set; }
        public int? CustomerID { get; set; }
        public ICollection<OrderDetails>? OrderDetails { get; set; }
    }
}

using DAL.Enums;
using DAL.Models.Enums;

namespace DAL.Models
{
    public class Order : BaseEntity
    {
       // public int OrderId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string ShippingAddress { get; set; }
        public float TotalAmount { get; set; }

        //Relationships
        public ShoppingCart? ShoppingCart { get; set; }
        public int? CartID { get; set; }
        public Payment? Payment { get; set; }
        public Customer? Customer { get; set; }
        public int? CustomerID { get; set; }
        public ICollection<OrderDetails>? OrderDetails { get; set; }
    }
}

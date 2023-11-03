using DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string ShippingAddress { get; set; }
        public float TotalAmount { get; set; }

        //Relationships
        //public ShoppingCart? ShoppingCart { get; set; }
        //public int CartID { get; set; }
        //public Payment? Payment { get; set; }
        //public int PaymentID { get; set; }
        //public List<OrderDetails>? Details { get; set; }
    }
}

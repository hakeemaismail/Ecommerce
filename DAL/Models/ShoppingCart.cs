using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ShoppingCart
    {
        public int CartID { get; set; }
        public DateTime DateTime { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        //Relationships
        //public ApplicationUser? User { get; set; }
        //public Guid UserID { get; set; }
        //public Order? Order { get; set; }
        //public int OrderID { get; set; }
        //public List<CartDetails>? CartDetails { get; set; }
    }
}

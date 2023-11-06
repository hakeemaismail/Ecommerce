using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ShoppingCart
    {
        [Key]
        public int CartID { get; set; }
        public DateTime DateTime { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        //Relationships
        public Order? Order { get; set; }
        public ICollection<CartDetails>? CartDetails { get; set; }
        public int? CustomerID { get; set; }
        public Customer? Customer { get; set; }
    }
}

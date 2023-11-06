using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }

        //relationships
        public ICollection<Payment>? Payments { get; set; }
        public ICollection<Order>? Orders { get; set;}
        public ShoppingCart? ShoppingCart { get; set; }
    }
}

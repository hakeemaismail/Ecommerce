using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CartDetails
    {
        public ShoppingCart Cart { get; set; }
        public int CartID { get; set; }
        public Product Product { get; set; }
        public int ProductID { get; set; } 
    }
}

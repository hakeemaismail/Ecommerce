using Ecommerce.Models;

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

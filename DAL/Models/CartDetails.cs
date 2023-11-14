using Ecommerce.Models;
using System.Text.Json.Serialization;

namespace DAL.Models
{
    public class CartDetails
    {
        public ShoppingCart Cart { get; set; }
        public int CartID { get; set; }
        public Product Product { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; } = 1;
        public float Price { get; set; }

    }
}

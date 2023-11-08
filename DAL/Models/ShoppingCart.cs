using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class ShoppingCart : BaseEntity
    {
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

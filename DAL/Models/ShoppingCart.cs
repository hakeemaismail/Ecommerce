using System.Text.Json.Serialization;

namespace DAL.Models
{
    public class ShoppingCart : BaseEntity
    {
        public float? TotalAmount { get; set; }

        //Relationships
        public Order? Order { get; set; }
        public ICollection<CartDetails>? CartDetails { get; set; }
        public Customer? Customer { get; set; }
        public int? CustomerID { get; set; }
    }
}

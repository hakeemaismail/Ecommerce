namespace DAL.Models
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; }

        //relationships
        public ICollection<Payment>? Payments { get; set; }
        public ICollection<Order>? Orders { get; set;}
        public ICollection<ShoppingCart>? ShoppingCart { get; set; }
    }
}

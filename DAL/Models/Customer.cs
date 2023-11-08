namespace DAL.Models
{
    public class Customer : BaseEntity
    {
        //public int CustomerId { get; set; }
        public string FullName { get; set; }

        //relationships
        public ICollection<Payment>? Payments { get; set; }
        public ICollection<Order>? Orders { get; set;}
        public ShoppingCart? ShoppingCart { get; set; }
    }
}

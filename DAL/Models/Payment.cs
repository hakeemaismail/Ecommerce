using DAL.Enums;
using DAL.Models.Enums;

namespace DAL.Models
{
    public class Payment : BaseEntity
    {
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime DateTime { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public float PaymentAmount { get; set; }

        //Relationships
        public int? OrderID { get; set; }
        public Order? Order { get; set; }
        public Customer? Customer { get; set; }
        public int? CustomerID { get; set; }

    }
}

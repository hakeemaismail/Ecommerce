using DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
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

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Relationships 
        //public ShoppingCart? ShoppingCart { get; set; }
        //public int CartID { get; set; }
        //public List<Order>? OrderList { get; set; }
        //public List<Payment>? PaymentList { get; set; }
    }
}

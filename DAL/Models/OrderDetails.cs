﻿using Ecommerce.Models;

namespace DAL.Models
{
    public class OrderDetails
    {
        public int? ProductID { get; set; }
        public Product? Product { get; set; }
        public int? OrderID { get; set; }   
        public Order? Order { get; set; }   
        public int Quantity { get; set; }
        public float Price { get; set; }

    }
}

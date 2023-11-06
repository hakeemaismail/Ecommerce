using DAL.Models;
using DAL.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public float Price { get; set; }
        public string? Description { get; set; }
       

        //Relationships
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }    
        public ICollection<OrderDetails>? OrderDetails { get; set; }
        public ICollection<CartDetails>? CartDetails { get; set; }


    }
}

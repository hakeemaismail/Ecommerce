using Ecommerce.Models;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Category : BaseEntity
    {
       
       // public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        //Relationships
        public ICollection<Product>? Products { get; set; }
    }
}

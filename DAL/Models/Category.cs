using Ecommerce.Models;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        //Relationships
        public ICollection<Product>? Products { get; set; }
    }
}

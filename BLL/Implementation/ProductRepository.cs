using DAL.Repository;
using Ecommerce.Data;
using Ecommerce.Models;

namespace BLL.Implementation
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository 
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}

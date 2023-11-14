using BLL.Implementation;
using DAL.Models;
using DAL.Repository.IRepository;
using Ecommerce.Data;

namespace DAL.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}

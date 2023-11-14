using BLL.Implementation;
using DAL.Models;
using DAL.Repository.IRepository;
using Ecommerce.Data;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class OrderDetailsRepository : GenericRepository<OrderDetails>, IOrderDetailsRepository
    {
        private readonly DataContext _context;
        public OrderDetailsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<OrderDetails> getAllOrderDetails(int orderID)
        {
            Expression<Func<OrderDetails, bool>> predicate = order => order.OrderID == orderID;
            return _context.Set<OrderDetails>().Where(predicate).ToList();
        }
    }
}

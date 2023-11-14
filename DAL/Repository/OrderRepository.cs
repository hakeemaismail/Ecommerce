using BLL.Implementation;
using DAL.Models;
using DAL.Repository.IRepository;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<int> GetAllProductIDs(int cartID)
        {
            Expression<Func<CartDetails, bool>> predicate = cart => cart.CartID == cartID;
            return _context.Set<CartDetails>().Where(predicate).Select(cart => cart.ProductID).ToList();
        }

        public Order? GetOrderDetails(int OrderID)
        {
            Expression<Func<Order, bool>> predicate = order => order.Id == OrderID;
            return _context.Set<Order>().Where(predicate)
                .Include(order => order.OrderDetails)
                .FirstOrDefault();
        }
    }
}

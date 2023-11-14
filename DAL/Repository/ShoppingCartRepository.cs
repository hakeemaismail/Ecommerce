using BLL.Implementation;
using DAL.Models;
using DAL.Repository.IRepository;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly DataContext _context;
        public ShoppingCartRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public int? FindCustomerID(int cartID)
        {
            Expression<Func<ShoppingCart, bool>> predicate = customer => customer.Id == cartID;
            return _context.Set<ShoppingCart>().Where(predicate).Select(customer => customer.CustomerID).FirstOrDefault();
        }

        public float? GetTotalAmount(int cartID)
        {
            Expression<Func<ShoppingCart, bool>> predicate = customer => customer.Id == cartID;
            return _context.Set<ShoppingCart>().Where(predicate).Select(customer => customer.TotalAmount).FirstOrDefault();
        }

        public ShoppingCart? ViewShoppingCart(int cartID)
        {
            Expression<Func<ShoppingCart, bool>> predicate = cart => cart.Id == cartID;

            return _context.Set<ShoppingCart>().Where(predicate)
                .Include(cart => cart.CartDetails)
                .FirstOrDefault();
        }
    }
}
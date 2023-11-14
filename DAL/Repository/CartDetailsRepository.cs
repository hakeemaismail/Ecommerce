using BLL.Implementation;
using DAL.Models;
using DAL.Repository.IRepository;
using Ecommerce.Data;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class CartDetailsRepository : GenericRepository<CartDetails>, ICartDetailsRepository
    {
        private readonly DataContext _context;
        public CartDetailsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public int GetQuantityOfTheProductInCart(int ProductID)
        {
            Expression<Func<CartDetails, bool>> predicate = cart => cart.ProductID == ProductID;
            return _context.Set<CartDetails>().Where(predicate).Select(cart => cart.Quantity).FirstOrDefault();
        }

        public float GetPriceOfTheProductInCart(int ProductID)
        {
            Expression<Func<CartDetails, bool>> predicate = cart => cart.ProductID == ProductID;
            return _context.Set<CartDetails>().Where(predicate).Select(cart => cart.Price).FirstOrDefault();
        }

        public IEnumerable<float> PricesOfProductsInCart(int cartId)
        {
            Expression<Func<CartDetails, bool>> predicate = cart => cart.CartID == cartId;
            return _context.Set<CartDetails>().Where(predicate).Select(cart => cart.Price).ToList();
        }

        public CartDetails GetSpecificCartItem(int cartID, int productID)
        {
            Expression<Func<CartDetails, bool>> predicate = cart => cart.CartID == cartID && cart.ProductID == productID;
            return _context.Set<CartDetails>().FirstOrDefault(predicate);
        }
    }
}

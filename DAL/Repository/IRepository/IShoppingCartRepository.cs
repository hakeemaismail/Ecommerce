using DAL.Models;

namespace DAL.Repository.IRepository
{
    public interface IShoppingCartRepository : IGenericRepository<ShoppingCart>
    {
        int? FindCustomerID(int cartID);
        float? GetTotalAmount(int cartID);
        ShoppingCart? ViewShoppingCart(int cartID);
    }
}

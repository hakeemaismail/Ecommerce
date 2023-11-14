using DAL.Models;

namespace DAL.Repository.IRepository
{
    public interface ICartDetailsRepository : IGenericRepository<CartDetails>
    {
        int GetQuantityOfTheProductInCart(int ProductID);
        float GetPriceOfTheProductInCart(int ProductID);
        IEnumerable<float> PricesOfProductsInCart(int cartId);
        CartDetails GetSpecificCartItem(int cartID, int productID);
    }
}

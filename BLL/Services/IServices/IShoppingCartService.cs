using DAL.DTO;
using DAL.Models;

namespace BLL.Services.IServices
{
    public interface IShoppingCartService
    {
        Task<int> IncreaseQuantity(int cartID, int productID);
        Task<int> DecreaseQuantity(int cartID, int productID);
        Task<ViewShoppingCartDTO> ViewShoppingCart(int cartID);
        Task<bool> RemoveProductFromCart(int cartID, int productId);
        Task<ShoppingCartDTO> AddShoppingCart(int customerId);
        Task<bool> AddProductsToCart(CreateCartDetailsDTO cartDetailsDTO, int cartId, int customerId);
    }
}

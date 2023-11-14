using BLL.Services;
using BLL.Services.IServices;
using DAL.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }


        [HttpGet("GetShoppingCartId")]
        public async Task<int> AddShoppingCart(int CustomerID)
        {
            var result = await _shoppingCartService.AddShoppingCart(CustomerID);
            var Id = result.Id;
            return Id;
        }

        [HttpPost("AddProductsToCart")]
        public async Task<bool> AddProductsToCart(CreateCartDetailsDTO cartDetailsDTO, int cartId, int customerID)
        {
            var result = await _shoppingCartService.AddProductsToCart(cartDetailsDTO, cartId, customerID);
            return result;
        }

        [HttpGet("IncreaseQuantity")]
        public async Task<int> IncreaseQuantity(int cartId, int productId)
        {
            var result = await _shoppingCartService.IncreaseQuantity(cartId, productId);
            return result;
        }

        [HttpGet("DecreaseQuantity")]
        public async Task<int> DecreaseQuantity(int cartId, int productId)
        {
            var result = await _shoppingCartService.DecreaseQuantity(cartId, productId);
            return result;
        }

        [HttpGet("ViewShoppingCart")]
        public async Task<ViewShoppingCartDTO> ViewShoppingCart(int cartID)
        {
            var result = await _shoppingCartService.ViewShoppingCart(cartID);
            return result;
        }

        [HttpGet("RemoveProductFromShoppingCart")]
        public async Task<bool> RemoveFromCart(int cartID, int productID)
        {
            var result = await _shoppingCartService.RemoveProductFromCart(cartID, productID);
            return result;
        }
    }
}

using BLL.Services.IServices;
using DAL.DTO;
using Ecommerce.Models.DTO;
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
        public async Task<ResponseDTO<int>> AddShoppingCart(int CustomerID)
        {
            var result = await _shoppingCartService.AddShoppingCart(CustomerID);
            var Id = result.Id;
            var response = new ResponseDTO<int>
            {
                isSuccess = true,
                message = "Shopping Cart ID",
                code = StatusCodes.Status200OK,
                data = Id
            };
            return response;
        }

        [HttpPost("AddProductsToCart")]
        public async Task<ResponseDTO<bool>> AddProductsToCart(CreateCartDetailsDTO cartDetailsDTO, int cartId, int customerID)
        {
            var result = await _shoppingCartService.AddProductsToCart(cartDetailsDTO, cartId, customerID);
            var response = new ResponseDTO<bool>
            {
                isSuccess = true,
                message = "The product has been added to cart",
                code = StatusCodes.Status200OK,
                data = result
            };
            return response;
        }

        [HttpGet("IncreaseQuantity")]
        public async Task<ResponseDTO<int>> IncreaseQuantity(int cartId, int productId)
        {
            var result = await _shoppingCartService.IncreaseQuantity(cartId, productId);
            var response = new ResponseDTO<int>
            {
                isSuccess = true,
                message = "The quantity has been increased",
                code = StatusCodes.Status200OK,
                data = result
            };
            return response;
        }

        [HttpGet("DecreaseQuantity")]
        public async Task<ResponseDTO<int>> DecreaseQuantity(int cartId, int productId)
        {
            var result = await _shoppingCartService.DecreaseQuantity(cartId, productId);
            var response = new ResponseDTO<int>
            {
                isSuccess = true,
                message = "The quantity has been increased",
                code = StatusCodes.Status200OK,
                data = result
            };
            return response;
        }

        [HttpGet("ViewShoppingCart")]
        public async Task<ResponseDTO<ViewShoppingCartDTO>> ViewShoppingCart(int cartID)
        {
            var result = await _shoppingCartService.ViewShoppingCart(cartID);
            var response = new ResponseDTO<ViewShoppingCartDTO>
            {
                isSuccess = true,
                message = "Shopping cart details",
                code = StatusCodes.Status200OK,
                data = result
            };
            return response;
        }

        [HttpGet("RemoveProductFromShoppingCart")]
        public async Task<ResponseDTO<bool>> RemoveFromCart(int cartID, int productID)
        {
            var result = await _shoppingCartService.RemoveProductFromCart(cartID, productID);
            var response = new ResponseDTO<bool>
            {
                isSuccess = true,
                message = "The product has been removed from the cart",
                code = StatusCodes.Status200OK,
                data = result
            };
            return response;
        }
    }
}

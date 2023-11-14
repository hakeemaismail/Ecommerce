using AutoMapper;
using BLL.Services.IServices;
using DAL.DTO;
using DAL.Models;
using DAL.Repository.IRepository;

namespace BLL.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ShoppingCartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task UpdateTotalPriceInCart(int cartID)
        {
            var prices = _unitOfWork.CartDetails.PricesOfProductsInCart(cartID);

            float totalAmount = 0;
            foreach (var pr in prices)
            {
                totalAmount += pr;
            };

            var shoppingCart = _unitOfWork.ShoppingCart.GetById(cartID);
            shoppingCart.TotalAmount = totalAmount;
            await _unitOfWork.SaveAsync();
        }
        public async Task<ShoppingCartDTO> AddShoppingCart(int customerId)
        {
            var shoppingCart = new ShoppingCart
            {
                CustomerID = customerId
            };

            _unitOfWork.ShoppingCart.Add(shoppingCart);
            await _unitOfWork.SaveAsync();

            ShoppingCartDTO shoppingCartDTO = _mapper.Map<ShoppingCartDTO>(shoppingCart);
            return shoppingCartDTO;
        }

        public async Task<bool> AddProductsToCart(CreateCartDetailsDTO cartDetailsDTO, int cartId, int customerId)
        {
            var product = _unitOfWork.Products.GetById(cartDetailsDTO.ProductID);
            var price = product.Price;

            var cart = new CartDetailsDTO
            {
                CartID = cartId,
                ProductID = cartDetailsDTO.ProductID,
                Price = price
            };
            CartDetails cartDetails = _mapper.Map<CartDetails>(cart);
            _unitOfWork.CartDetails.Add(cartDetails);
            await _unitOfWork.SaveAsync();

            var prices = _unitOfWork.CartDetails.PricesOfProductsInCart(cartId);

            float totalAmount = 0;
            foreach (var pr in prices)
            {
                totalAmount += pr;
            };

            var shoppingCart = _unitOfWork.ShoppingCart.GetById(cartId);
            shoppingCart.TotalAmount = totalAmount;
            await _unitOfWork.SaveAsync();
            return true;
        }


        public async Task<int> DecreaseQuantity(int cartID, int productID)
        {
            var cart = _unitOfWork.CartDetails.GetSpecificCartItem(cartID, productID);
            if (cart != null)
            {
                int quantity = cart.Quantity;
                quantity -= 1;
                cart.Quantity = quantity;

                var Product = _unitOfWork.Products.GetById(productID);
                var Price = Product.Price;
                var FinalPrice = Price * cart.Quantity;
                cart.Price = FinalPrice;

                await _unitOfWork.SaveAsync();


                var prices = _unitOfWork.CartDetails.PricesOfProductsInCart(cartID);

                float totalAmount = 0;
                foreach (var pr in prices)
                {
                    totalAmount += pr;
                };

                var shoppingCart = _unitOfWork.ShoppingCart.GetById(cartID);
                shoppingCart.TotalAmount = totalAmount;
                await _unitOfWork.SaveAsync();

                return quantity;
            }
            else return -1;

        }

        public async Task<int> IncreaseQuantity(int cartID, int productID)
        {
            var cart = _unitOfWork.CartDetails.GetSpecificCartItem(cartID, productID);
            if (cart != null)
            {
                int quantity = cart.Quantity;
                quantity += 1;
                cart.Quantity = quantity;

                var Product = _unitOfWork.Products.GetById(productID);
                var Price = Product.Price;
                var FinalPrice = Price * cart.Quantity;
                cart.Price = FinalPrice;

                await _unitOfWork.SaveAsync();

                var prices = _unitOfWork.CartDetails.PricesOfProductsInCart(cartID);

                float totalAmount = 0;
                foreach (var pr in prices)
                {
                    totalAmount += pr;
                };

                var shoppingCart = _unitOfWork.ShoppingCart.GetById(cartID);
                shoppingCart.TotalAmount = totalAmount;
                await _unitOfWork.SaveAsync();

                return quantity;
            }
            else return -1;
        }

        public async Task<bool> RemoveProductFromCart(int cartID, int productId)
        {
            var product = _unitOfWork.CartDetails.GetSpecificCartItem(cartID, productId);
            _unitOfWork.CartDetails.Remove(product);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<ViewShoppingCartDTO> ViewShoppingCart(int cartID)
        {
            var Shoppingcart = _unitOfWork.ShoppingCart.ViewShoppingCart(cartID);
            ViewShoppingCartDTO ShoppingCartDTO = new ViewShoppingCartDTO
            {
                CartID = cartID,
                TotalAmount = Shoppingcart.TotalAmount ?? 0,
                ProductsInCart = Shoppingcart.CartDetails.Select(x => new ViewProductsInCartDTO
                {
                    ProductId = x.ProductID,
                    Quantity = x.Quantity,
                    Price = x.Price,
                }).ToList(),
               
            };
            return ShoppingCartDTO;     
        }


    }
}

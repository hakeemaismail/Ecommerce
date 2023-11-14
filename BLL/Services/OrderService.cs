using BLL.Services.IServices;
using DAL.DTO;
using DAL.Models;
using DAL.Repository.IRepository;
using AutoMapper;
using DAL.Models.Enums;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> ConfirmOrder(int cartId)
        {
            var productIds = _unitOfWork.Orders.GetAllProductIDs(cartId);
            var order = new Order();
            order.CartID = cartId;
            var customerID = _unitOfWork.ShoppingCart.FindCustomerID(cartId);
            order.CustomerID = customerID;
            var totalAmount = _unitOfWork.ShoppingCart.GetTotalAmount(cartId);
            order.TotalAmount = totalAmount;
            _unitOfWork.Orders.Add(order);
            await _unitOfWork.SaveAsync();

            OrderDTO orderDTO = _mapper.Map<OrderDTO>(order);
            var orderID = orderDTO.Id;

            foreach (var productId in productIds)
            {
                var quantity = _unitOfWork.CartDetails.GetQuantityOfTheProductInCart(productId);
                var price = _unitOfWork.CartDetails.GetPriceOfTheProductInCart(productId);

                var orderDetails = new OrderDetailsDTO
                {
                    ProductID = productId,
                    OrderID = orderID,
                    Quantity = quantity,
                    Price = price
                };

                OrderDetails orderDetails1 = _mapper.Map<OrderDetails>(orderDetails);
                _unitOfWork.OrderDetails.Add(orderDetails1);
                await _unitOfWork.SaveAsync();
            }

            return true;
        }

        public async Task<bool> CancelOrder(int orderId)
        {
            var OrderDetails = _unitOfWork.OrderDetails.getAllOrderDetails(orderId);
            _unitOfWork.OrderDetails.RemoveRange(OrderDetails);
            await _unitOfWork.SaveAsync();

            var order = _unitOfWork.Orders.GetById(orderId);
            order.OrderStatus = DAL.Models.Enums.OrderStatus.Cancelled;
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateOrderStatus(int orderId, OrderStatus newStatus)
        {
            var Order = _unitOfWork.Orders.GetById(orderId);
            Order.OrderStatus = newStatus;
            await _unitOfWork.SaveAsync();
            return true;

        }

        public async Task<ViewOrderDetailsDTO> ViewOrderDetails(int orderId)
        {
            var OrderDeets = _unitOfWork.Orders.GetOrderDetails(orderId);
            
                ViewOrderDetailsDTO viewOrderDetailsDTO = new ViewOrderDetailsDTO
                {
                    Id = orderId,
                    TotalAmount = OrderDeets.TotalAmount ?? 0,
                    Details = OrderDeets.OrderDetails.Select(x => new OrderBriefDTO
                    {
                        ProductID = x.ProductID ?? 0,
                        Quantity = x.Quantity,
                        Price = x.Price,
                    }).ToList()

                };
            return viewOrderDetailsDTO;
            
        }
    }
}

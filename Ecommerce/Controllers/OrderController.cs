using BLL.Services.IServices;
using DAL.DTO;
using DAL.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("ConfirmOrder")]
        public Task<bool> ConfirmOrder(int cartId)
        {
            var result = _orderService.ConfirmOrder(cartId);
            return result;
        }

        [HttpPost("CancelOrder")]
        public Task<bool> CancelOrder(int orderId)
        {
            var result = _orderService.CancelOrder(orderId);
            return result;
        }

        [HttpPost("UpdateOrderStatus")]
        public Task<bool> UpdateOrderStatus(int OrderID, OrderStatus orderStatus)
        {
            var result = _orderService.UpdateOrderStatus(OrderID, orderStatus);
            return result;
        }

        [HttpGet("ViewOrderDetails")]
        public Task<ViewOrderDetailsDTO> ViewOrderDetails(int OrderID)
        {
            var result = _orderService.ViewOrderDetails(OrderID);
            return result;
        }

    }
}

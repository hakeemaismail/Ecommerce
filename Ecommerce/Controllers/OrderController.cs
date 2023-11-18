using BLL.Services.IServices;
using DAL.DTO;
using DAL.Models.Enums;
using Ecommerce.Models.DTO;
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
        public async Task<ResponseDTO<bool>> ConfirmOrder(int cartId)
        {
            var result = await _orderService.ConfirmOrder(cartId);
            var response = new ResponseDTO<bool>
            {
                isSuccess = true,
                message = "Order has been confirmed",
                code = StatusCodes.Status200OK,
                data = result
            };
            return response;
        }

        [HttpPost("CancelOrder")]
        public async Task<ResponseDTO<bool>> CancelOrder(int orderId)
        {
            var result = await _orderService.CancelOrder(orderId);
            var response = new ResponseDTO<bool>
            {
                isSuccess = true,
                message = "Order has been cancelled",
                code = StatusCodes.Status200OK,
                data = result
            };
            return response;
        }

        [HttpPost("UpdateOrderStatus")]
        public async Task<ResponseDTO<bool>> UpdateOrderStatus(int OrderID, OrderStatus orderStatus)
        {
            var result = await _orderService.UpdateOrderStatus(OrderID, orderStatus);
            var response = new ResponseDTO<bool>
            {
              isSuccess = true,
              message = "Order status updated successfully",
              code = StatusCodes.Status200OK,
              data = result
            };
            return response;
        }

        [HttpGet("ViewOrderDetails")]
        public async Task<ResponseDTO<ViewOrderDetailsDTO>> ViewOrderDetails(int OrderID)
        {
            var result = await _orderService.ViewOrderDetails(OrderID);
            var response = new ResponseDTO<ViewOrderDetailsDTO>
            {
                isSuccess = true,
                message = "Order Details",
                code = StatusCodes.Status200OK,
                data = result
            };
            return response;
        }

    }
}

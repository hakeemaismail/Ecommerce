using DAL.DTO;
using DAL.Models.Enums;

namespace BLL.Services.IServices
{
    public interface IOrderService
    {
        Task<bool> ConfirmOrder(int cartId);
        Task<bool> CancelOrder(int orderId);
        Task<bool> UpdateOrderStatus(int orderId, OrderStatus newStatus);
        Task<ViewOrderDetailsDTO> ViewOrderDetails(int orderId);
    }
}

using DAL.Models;

namespace DAL.Repository.IRepository
{
    public interface IOrderDetailsRepository : IGenericRepository<OrderDetails>
    {
        IEnumerable<OrderDetails> getAllOrderDetails(int orderID);
    }
}

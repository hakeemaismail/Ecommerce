using DAL.Models;

namespace DAL.Repository.IRepository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IEnumerable<int> GetAllProductIDs(int OrderID);
        Order? GetOrderDetails(int OrderID);
       
    }
}

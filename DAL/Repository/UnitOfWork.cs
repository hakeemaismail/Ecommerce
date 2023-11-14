using DAL.Repository;
using DAL.Repository.IRepository;
using Ecommerce.Data;

namespace BLL.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _db;
        public UnitOfWork(DataContext db)
        {
            _db = db;
            Products = new ProductRepository(_db);
            Orders = new OrderRepository(_db);
            CartDetails = new CartDetailsRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            Customer = new CustomerRepository(_db);
            OrderDetails = new OrderDetailsRepository(_db);
        }

        public IProductRepository Products { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public ICartDetailsRepository CartDetails { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public ICustomerRepository Customer { get; private set; }
        public IOrderDetailsRepository OrderDetails { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
            //_db.SaveChangesAsync().GetAwaiter().GetResult();
        }
        //public void SaveAsync()
        //{
        //    _db.SaveChangesAsync().GetAwaiter().GetResult();
        //}

    }
}

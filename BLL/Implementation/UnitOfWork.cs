using DAL.Repository;
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
        }
    
        public IProductRepository Products { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void SaveAsync()
        {
            _db.SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}

namespace DAL.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        ICartDetailsRepository CartDetails { get; }
        IShoppingCartRepository ShoppingCart { get; }
        ICustomerRepository Customer { get; }
        IOrderDetailsRepository OrderDetails { get; }

        //void SaveAsync();
        Task SaveAsync();
    }
}

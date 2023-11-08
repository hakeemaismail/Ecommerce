namespace DAL.Repository
{
    public interface IUnitOfWork : IDisposable
    {
      IProductRepository Products { get; }
      void SaveAsync();
    }
}

using Restaurante.Repositories;

namespace Restaurante.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> Complete();
    }
}
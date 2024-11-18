using UnitOfWork.Domain.Models;

namespace UnitOfWork.Contracts.Contracts
{
    public interface IRepository<TEntity>
        where TEntity : EntityBase
    {
        void SetContext(object context);

        Task<TEntity?> GetById(Guid id);
        IQueryable<TEntity> Get();
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
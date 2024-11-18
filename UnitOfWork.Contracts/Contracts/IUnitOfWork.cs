using UnitOfWork.Domain.Models;

namespace UnitOfWork.Contracts.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>()
            where T : EntityBase;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

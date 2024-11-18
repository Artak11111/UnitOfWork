using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using UnitOfWork.Contracts.Contracts;
using UnitOfWork.Domain.Models;

namespace UnitOfWork.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            Context = ServiceProvider.GetService<DbContext>()!;
        }

        protected IServiceProvider ServiceProvider { get; }

        protected DbContext Context { get; }

        public IRepository<T> Repository<T>()
            where T : EntityBase
        {
            var repository = ServiceProvider.GetService<IRepository<T>>()
                ?? throw new InvalidOperationException("Repository is not registered in DI container");

            return repository;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

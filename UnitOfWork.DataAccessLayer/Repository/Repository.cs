using Microsoft.EntityFrameworkCore;

using UnitOfWork.Contracts.Contracts;
using UnitOfWork.Domain.Models;

namespace UnitOfWork.DataAccessLayer.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        protected DbContext Context { get; private set; }

        public Repository(DbContext context)
        {
            Context = context;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }

        public void Delete(TEntity entity)
        {
            Set().Remove(entity);
        }

        protected DbSet<TEntity> Set()
        {
            return Context.Set<TEntity>();
        }

        public Task<TEntity?> GetById(Guid id)
        {
            return Set().FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<TEntity> Get()
        {
            return Set();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await Set().AddAsync(entity)).Entity;
        }

        public TEntity Update(TEntity entity)
        {
            return Set().Update(entity).Entity;
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return Set().ToListAsync();
        }
    }
}
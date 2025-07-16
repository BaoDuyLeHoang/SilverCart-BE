using SilverCart.Application.Repositories;
using SilverCart.Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class GenericMutationRepository<TEntity> : IGenericMutationRepository<TEntity> where TEntity : class, IAuditableEntity
    {
        protected readonly DbSet<TEntity> _dbSet;
        public GenericMutationRepository(AppDbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(List<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void SoftRemove(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void SoftRemoveRange(List<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }
    }
}
using System.Linq.Expressions;
using SilverCart.Application.Interfaces;
using SilverCart.Application.Repositories;
using SilverCart.Application.Commons;
using SilverCart.Domain.Common.Interfaces;
using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IAuditableEntity, IBaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }

        public async Task<TEntity?> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            var entity = await query.FirstOrDefaultAsync(x => x.Id == id);
            // Optional: throw custom NotFoundException
            return entity;
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

        public async Task<Pagination<TEntity>> ToPagination(int pageIndex = 0, int pageSize = 10)
        {
            var total = await _dbSet.CountAsync();
            var items = await _dbSet.OrderByDescending(x => typeof(IAuditableEntity).IsAssignableFrom(x.GetType())
                    ? ((IAuditableEntity)x).CreationDate
                    : DateTime.MinValue)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            return new Pagination<TEntity>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItemsCount = total,
                Items = items
            };
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            if (includes != null && includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await Task.FromResult(query);
        }
        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await Task.FromResult(query);
        }
        public async Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return await query.FirstOrDefaultAsync(predicate);
        }

    }
}
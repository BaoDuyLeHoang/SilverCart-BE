using System.Linq.Expressions;
using SilverCart.Application.Interfaces;
using SilverCart.Application.Repositories;
using SilverCart.Domain.Common.Interfaces;
using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructures.Commons.Paginations;
using SilverCart.Domain.Commons.Enums;

namespace Infrastructures.Repositories
{
    public class GenericRepository<TEntity> : GenericMutationRepository<TEntity>, IGenericRepository<TEntity>
        where TEntity : class, IBaseEntity, IAuditableEntity
    {
        public GenericRepository(AppDbContext context) : base(context)
        {
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
            return entity;
        }

        public async Task<TEntity?> GetByIdAsync(Guid id, Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, object>>[]? includes = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (includes != null && includes.Any())
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            var entity = await query.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task<PagedResult<TEntity>> ToPaginationAsync(
            int pageNumber = 1,
            int pageSize = 10,
            Expression<Func<TEntity, bool>>? predicate = null,
            string? sortColumn = null,
            SortOrder? sortOrder = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            // Start with base query
            IQueryable<TEntity> query = _dbSet;

            // Apply includes
            query = includes.Aggregate(query, (current, include) => current.Include(include));

            // Apply predicate if provided
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            // Get total count before pagination
            var total = await query.CountAsync();

            // Apply sorting
            if (!string.IsNullOrWhiteSpace(sortColumn))
            {
                var property = typeof(TEntity).GetProperty(sortColumn, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                if (property != null)
                {
                    var parameter = Expression.Parameter(typeof(TEntity), "x");
                    var propertyAccess = Expression.Property(parameter, property);
                    var lambda = Expression.Lambda<Func<TEntity, object>>(Expression.Convert(propertyAccess, typeof(object)), parameter);

                    query = sortOrder == SortOrder.Descending
                        ? query.OrderByDescending(lambda)
                        : query.OrderBy(lambda);
                }
            }
            else
            {
                // Default sort by creation date
                query = query.OrderByDescending(x => x.CreationDate);
            }

            // Apply pagination
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            // Return paged result
            return new PagedResult<TEntity>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalNumberOfRecords = total,
                Results = items
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
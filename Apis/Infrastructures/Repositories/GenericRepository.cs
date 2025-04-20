using System.Linq.Expressions;
using Application.Interfaces;
using Application.Repositories;
using Application.Commons;
using Domain.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseFullEntity
    {
        protected readonly DbSet<TEntity> _dbSet;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;

        public GenericRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService)
        {
            _dbSet = context.Set<TEntity>();
            _timeService = timeService;
            _claimsService = claimsService;
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
            var items = await _dbSet.OrderByDescending(x => typeof(IDateTracking).IsAssignableFrom(x.GetType())
                    ? ((IDateTracking)x).CreationDate
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
    }
}
using System.Linq.Expressions;
using SilverCart.Domain.Common.Interfaces;
using SilverCart.Domain.Entities;
using Infrastructures.Commons.Paginations;
using SilverCart.Domain.Commons.Enums;

namespace SilverCart.Application.Repositories
{
    public interface IGenericRepository<TEntity> : IGenericMutationRepository<TEntity> where TEntity : class, IBaseEntity, IAuditableEntity
    {
        Task<IQueryable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);
        Task<TEntity?> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> GetByIdAsync(Guid id, Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, object>>[]? includes = null);
        Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<PagedResult<TEntity>> ToPaginationAsync(
            int pageNumber = 1,
            int pageSize = 10,
            Expression<Func<TEntity, bool>>? predicate = null,
            string? sortColumn = null,
            SortOrder? sortOrder = null,
            params Expression<Func<TEntity, object>>[] includes);
    }
}
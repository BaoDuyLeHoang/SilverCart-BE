using System.Linq.Expressions;
using SilverCart.Application.Commons;
using SilverCart.Domain.Common.Interfaces;
using SilverCart.Domain.Entities;

namespace SilverCart.Application.Repositories
{
    public interface IGenericMutationRepository<TEntity> where TEntity : class, IAuditableEntity
    {
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        void SoftRemove(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        void SoftRemoveRange(List<TEntity> entities);
    }
}
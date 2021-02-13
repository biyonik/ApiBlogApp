using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiBlogApp.Entities.Abstract;

namespace ApiBlogApp.DataAccess.Abstract.Base
{
    public interface IGenericRepositoryDal<TEntity> where TEntity:class, IEntity, new()
    {
        Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<IList<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector,
            Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
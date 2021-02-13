using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBlogApp.Entities.Abstract;

namespace ApiBlogApp.BusinessLogic.Abstract.Base
{
    public interface IGenericService<TEntity> where TEntity:class, IEntity, new()
    {
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> FindByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
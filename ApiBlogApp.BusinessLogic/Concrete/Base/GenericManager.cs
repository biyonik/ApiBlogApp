using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBlogApp.BusinessLogic.Abstract.Base;
using ApiBlogApp.DataAccess.Abstract.Base;
using ApiBlogApp.Entities.Abstract;

namespace ApiBlogApp.BusinessLogic.Concrete.Base
{
    public class GenericManager<TEntity>:IGenericService<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IGenericRepositoryDal<TEntity> _genericRepositoryDal;

        public GenericManager(IGenericRepositoryDal<TEntity> genericRepositoryDal)
        {
            _genericRepositoryDal = genericRepositoryDal;
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _genericRepositoryDal.GetAllAsync();
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _genericRepositoryDal.FindByIdAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _genericRepositoryDal.AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _genericRepositoryDal.UpdateAsync(entity);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await _genericRepositoryDal.RemoveAsync(entity);
        }
    }
}
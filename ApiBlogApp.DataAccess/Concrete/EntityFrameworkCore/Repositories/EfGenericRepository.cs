using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiBlogApp.DataAccess.Abstract.Base;
using ApiBlogApp.DataAccess.Concrete.EntityFrameworkCore.Context;
using ApiBlogApp.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ApiBlogApp.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity>: IGenericRepositoryDal<TEntity> where TEntity : class, IEntity, new()
    {
        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            await using var context = new ApiBlogAppContext();
            return filter == null
                ? await context.Set<TEntity>().ToListAsync()
                : await context.Set<TEntity>().Where(filter).ToListAsync();
        }
        
        public async Task<IList<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector,
            Expression<Func<TEntity, bool>> filter = null)
        {
            await using var context = new ApiBlogAppContext();
            return filter == null
                ? await context.Set<TEntity>().OrderByDescending(keySelector).ToListAsync()
                : await context.Set<TEntity>().OrderByDescending(keySelector).Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            await using var context = new ApiBlogAppContext();
            return await context.Set<TEntity>().Where(filter).SingleOrDefaultAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await using var context = new ApiBlogAppContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await using var context = new ApiBlogAppContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await using var context = new ApiBlogAppContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
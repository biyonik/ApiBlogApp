﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBlogApp.BusinessLogic.Abstract;
using ApiBlogApp.BusinessLogic.Concrete.Base;
using ApiBlogApp.DataAccess.Abstract.Base;
using ApiBlogApp.Entities.Concrete;

namespace ApiBlogApp.BusinessLogic.Concrete
{
    public class CategoryManager: GenericManager<Category>, ICategoryService
    {
        private readonly IGenericRepositoryDal<Category> _genericRepositoryDal;
        public CategoryManager(IGenericRepositoryDal<Category> genericRepositoryDal) : base(genericRepositoryDal)
        {
            _genericRepositoryDal = genericRepositoryDal;
        }

        public async Task<List<Category>> GetAllSortedById()
        {
            return await _genericRepositoryDal.GetAllAsync(x => x.Id, null) as List<Category>;
        }
    }
}
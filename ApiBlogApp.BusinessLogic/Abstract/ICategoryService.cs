using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBlogApp.BusinessLogic.Abstract.Base;
using ApiBlogApp.Entities.Concrete;

namespace ApiBlogApp.BusinessLogic.Abstract
{
    public interface ICategoryService: IGenericService<Category>
    {
        Task<List<Category>> GetAllSortedById();
    }
}
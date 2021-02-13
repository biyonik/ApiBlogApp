using ApiBlogApp.BusinessLogic.Abstract;
using ApiBlogApp.BusinessLogic.Concrete.Base;
using ApiBlogApp.DataAccess.Abstract.Base;
using ApiBlogApp.Entities.Concrete;

namespace ApiBlogApp.BusinessLogic.Concrete
{
    public class BlogManager: GenericManager<Blog>,IBlogService
    {
        private readonly IGenericRepositoryDal<Blog> _genericRepositoryDal;
        public BlogManager(IGenericRepositoryDal<Blog> genericRepositoryDal) : base(genericRepositoryDal)
        {
            _genericRepositoryDal = genericRepositoryDal;
        }
    }
}
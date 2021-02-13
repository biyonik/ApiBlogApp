using ApiBlogApp.BusinessLogic.Abstract;
using ApiBlogApp.BusinessLogic.Concrete.Base;
using ApiBlogApp.DataAccess.Abstract.Base;
using ApiBlogApp.Entities.Concrete;

namespace ApiBlogApp.BusinessLogic.Concrete
{
    public class AppUserManager: GenericManager<AppUser>, IAppUserService
    {
        private readonly IGenericRepositoryDal<AppUser> _genericRepositoryDal;
        public AppUserManager(IGenericRepositoryDal<AppUser> genericRepositoryDal) : base(genericRepositoryDal)
        {
            _genericRepositoryDal = genericRepositoryDal;
        }
    }
}
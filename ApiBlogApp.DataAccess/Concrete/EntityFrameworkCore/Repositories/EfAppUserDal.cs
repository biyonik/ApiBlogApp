using ApiBlogApp.DataAccess.Abstract;
using ApiBlogApp.DataAccess.Concrete.EntityFrameworkCore.Repositories.Base;
using ApiBlogApp.Entities.Concrete;

namespace ApiBlogApp.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserDal: EfGenericRepository<AppUser>, IAppUserDal
    {
        
    }
}
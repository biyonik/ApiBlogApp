using ApiBlogApp.BusinessLogic.Abstract;
using ApiBlogApp.BusinessLogic.Concrete;
using ApiBlogApp.DataAccess.Abstract.Base;
using ApiBlogApp.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ApiBlogApp.BusinessLogic.Containers.Microsoft
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepositoryDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
        }
    }
}
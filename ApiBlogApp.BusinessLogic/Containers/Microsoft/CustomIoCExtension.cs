using ApiBlogApp.BusinessLogic.Abstract;
using ApiBlogApp.BusinessLogic.Abstract.Base;
using ApiBlogApp.BusinessLogic.Concrete;
using ApiBlogApp.BusinessLogic.Concrete.Base;
using ApiBlogApp.DataAccess.Abstract;
using ApiBlogApp.DataAccess.Abstract.Base;
using ApiBlogApp.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using ApiBlogApp.DataAccess.Concrete.EntityFrameworkCore.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace ApiBlogApp.BusinessLogic.Containers.Microsoft
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepositoryDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, EfBlogDal>();
        }
    }
}
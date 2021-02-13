using ApiBlogApp.DataAccess.Abstract.Base;
using ApiBlogApp.Entities.Concrete;

namespace ApiBlogApp.DataAccess.Abstract
{
    public interface ICommentDal: IGenericRepositoryDal<Comment>
    {
        
    }
}
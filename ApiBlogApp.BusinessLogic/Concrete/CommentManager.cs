using ApiBlogApp.BusinessLogic.Abstract;
using ApiBlogApp.BusinessLogic.Concrete.Base;
using ApiBlogApp.DataAccess.Abstract.Base;
using ApiBlogApp.Entities.Concrete;

namespace ApiBlogApp.BusinessLogic.Concrete
{
    public class CommentManager: GenericManager<Comment>, ICommentService
    {
        private readonly IGenericRepositoryDal<Comment> _genericRepositoryDal;
        public CommentManager(IGenericRepositoryDal<Comment> genericRepositoryDal) : base(genericRepositoryDal)
        {
            _genericRepositoryDal = genericRepositoryDal;
        }
    }
}
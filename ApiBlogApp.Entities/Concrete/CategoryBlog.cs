using ApiBlogApp.Entities.Abstract;

namespace ApiBlogApp.Entities.Concrete
{
    public class CategoryBlog: IEntity
    {
        public int Id { get; set; }
        
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
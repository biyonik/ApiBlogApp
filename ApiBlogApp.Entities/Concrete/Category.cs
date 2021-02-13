using System.Collections.Generic;
using ApiBlogApp.Entities.Abstract;

namespace ApiBlogApp.Entities.Concrete
{
    public class Category: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}
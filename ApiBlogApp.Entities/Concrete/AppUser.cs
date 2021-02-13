using System.Collections.Generic;
using ApiBlogApp.Entities.Abstract;

namespace ApiBlogApp.Entities.Concrete
{
    public class AppUser: IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public virtual List<Blog> Blogs { get; set; }
    }
}
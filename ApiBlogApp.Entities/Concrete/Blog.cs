using System;
using System.Collections.Generic;
using ApiBlogApp.Entities.Abstract;

namespace ApiBlogApp.Entities.Concrete
{
    public class Blog: IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public DateTime PostedTime { get; set; }

        public List<Category> Categories { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
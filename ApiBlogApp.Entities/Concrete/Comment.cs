using System;
using System.Collections.Generic;
using ApiBlogApp.Entities.Abstract;

namespace ApiBlogApp.Entities.Concrete
{
    public class Comment: IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public DateTime PostedTime { get; set; } = DateTime.Now;

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

        public int? ParentCommentId { get; set; }
        public virtual Comment ParentComment { get; set; }
        public List<Comment> SubComments { get; set; }
    }
}
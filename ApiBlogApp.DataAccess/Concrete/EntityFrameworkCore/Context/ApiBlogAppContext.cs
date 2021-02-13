using ApiBlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ApiBlogApp.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class ApiBlogAppContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=ApiBlogAppDb;Integrated Security=true");
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryBlog> CategoryBlogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
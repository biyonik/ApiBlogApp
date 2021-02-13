using ApiBlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiBlogApp.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class BlogMap : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.ShortDescription)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.Content)
                .HasColumnType("ntext")
                .HasMaxLength(2048)
                .IsRequired();

            builder.Property(x => x.ImagePath)
                .HasMaxLength(256);

            builder.HasMany<Comment>(x => x.Comments).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId);
            builder.HasMany<CategoryBlog>(x => x.CategoryBlogs).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId);
        }
    }
}
using ApiBlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiBlogApp.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class CategoryBlogMap: IEntityTypeConfiguration<CategoryBlog>
    {
        public void Configure(EntityTypeBuilder<CategoryBlog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasIndex(x => new
            {
                x.BlogId,
                x.CategoryId
            }).IsUnique();
        }
    }
}
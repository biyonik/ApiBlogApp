using ApiBlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiBlogApp.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class CategoryMap: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.HasMany<CategoryBlog>(x => x.CategoryBlogs).WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
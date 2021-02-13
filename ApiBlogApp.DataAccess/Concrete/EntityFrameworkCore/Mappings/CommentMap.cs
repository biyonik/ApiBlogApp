using ApiBlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiBlogApp.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.AuthorName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.AuthorEmail)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne<Comment>(x => x.ParentComment).WithMany(x => x.SubComments)
                .HasForeignKey(x => x.ParentCommentId);

            builder.HasOne<Blog>(x => x.Blog).WithMany(x => x.Comments).HasForeignKey(x => x.BlogId);
        }
    }
}
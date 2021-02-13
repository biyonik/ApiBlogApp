using ApiBlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiBlogApp.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class AppUserMap: IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.UserName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(100);

            builder.Property(x => x.FirstName)
                .HasMaxLength(32);

            builder.Property(x => x.LastName)
                .HasMaxLength(32);

            builder.HasMany<Blog>(x => x.Blogs)
                .WithOne(x => x.AppUser)
                .HasForeignKey(x => x.AppUserId);
        }
    }
}
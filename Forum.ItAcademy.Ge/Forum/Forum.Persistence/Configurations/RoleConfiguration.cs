using Forum.Domain;
using Forum.Domain.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(role => role.Name).IsRequired();

            builder.Property(role => role.CreatedAt)
                .IsRequired();

            builder.Property(role => role.ModifiedAt)
                .IsRequired();

            builder.Property(role => role.Status)
                .IsRequired()
                .HasDefaultValue(Status.Active);

            // Ignored properties
            builder.Ignore(role => role.ConcurrencyStamp);
        }
    }
}

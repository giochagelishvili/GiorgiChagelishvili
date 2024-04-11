using Forum.Domain;
using Forum.Domain.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Persistence.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(comment => comment.Id);

            builder.Property(comment => comment.Body)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(comment => comment.CreatedAt)
                .IsRequired();

            builder.Property(comment => comment.ModifiedAt)
                .IsRequired();

            builder.Property(comment => comment.Status)
                .IsRequired()
                .HasDefaultValue(Status.Active);
        }
    }
}

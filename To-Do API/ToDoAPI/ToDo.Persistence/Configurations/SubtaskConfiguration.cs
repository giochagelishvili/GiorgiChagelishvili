using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.BaseEntities;
using ToDo.Domain.Subtasks;

namespace ToDo.Persistence.Configurations
{
    public class SubtaskConfiguration : IEntityTypeConfiguration<Subtask>
    {
        public void Configure(EntityTypeBuilder<Subtask> builder)
        {
            builder.Property(subtask => subtask.Title).IsRequired().HasMaxLength(100);

            builder.Property(subtask => subtask.ToDoItemId).IsRequired();

            builder.Property(subtask => subtask.CreatedAt).IsRequired();

            builder.Property(subtask => subtask.ModifiedAt).IsRequired();

            builder.Property(subtask => subtask.Status).IsRequired().HasDefaultValue(Status.Active);

            builder.HasOne(subtask => subtask.ToDoItem)
                   .WithMany(toDoItem => toDoItem.Subtasks)
                   .HasForeignKey(subtask => subtask.ToDoItemId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.BaseEntities;
using ToDo.Domain.ToDos;

namespace ToDo.Persistence.Configurations
{
    public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.Property(toDoItem => toDoItem.Title).IsRequired().HasMaxLength(100);

            builder.Property(toDoItem => toDoItem.Status).IsRequired().HasDefaultValue(Status.Active);

            builder.Property(toDoItem => toDoItem.CreatedAt).IsRequired();

            builder.Property(toDoItem => toDoItem.ModifiedAt).IsRequired();

            builder.HasMany(toDoItem => toDoItem.Subtasks).WithOne(subTask => subTask.ToDoItem);

            builder.HasOne(toDoItem => toDoItem.Owner)
                   .WithMany(owner => owner.ToDoItems)
                   .HasForeignKey(toDoItem => toDoItem.OwnerId);
        }
    }
}

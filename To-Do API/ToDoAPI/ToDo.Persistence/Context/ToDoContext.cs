using Microsoft.EntityFrameworkCore;
using ToDo.Domain.BaseEntities;
using ToDo.Domain.Users;

namespace ToDo.Persistence.Context
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var trackedEntries = base.ChangeTracker.Entries<BaseEntity>()
                                 .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified);

            foreach (var entry in trackedEntries)
            {
                entry.Entity.ModifiedAt = DateTime.Now.ToUniversalTime();

                if (entry.State == EntityState.Added)
                    entry.Entity.ModifiedAt = DateTime.Now.ToUniversalTime();
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

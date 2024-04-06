using Forum.Domain.BaseEntities;
using Forum.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forum.Persistence.Context
{
    public class ForumContext : IdentityDbContext<User>
    {
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForumContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var trackedEntries = base.ChangeTracker.Entries<IEntity>()
                                     .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified);

            foreach (var entry in trackedEntries)
            {
                entry.Entity.ModifiedAt = DateTime.Now.ToUniversalTime();

                if (entry.State == EntityState.Added)
                    entry.Entity.CreatedAt = DateTime.Now.ToUniversalTime();
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

using Forum.Domain.BaseEntities;
using Forum.Domain.Roles;
using Forum.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forum.Persistence.Context
{
    public class ForumContext : IdentityDbContext<User, Role, string>
    {
        public ForumContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUserLogin<string>>();

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");

            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

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

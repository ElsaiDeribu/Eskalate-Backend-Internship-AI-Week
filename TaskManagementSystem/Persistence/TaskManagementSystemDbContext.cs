using Domain;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class TaskManagementSystemDbContext : DbContext
    {
        public TaskManagementSystemDbContext(DbContextOptions<TaskManagementSystemDbContext> options)
                    : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagementSystemDbContext).Assembly);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }


            return base.SaveChangesAsync(cancellationToken);
        }

         public DbSet<Domain.Task> Tasks { get; set; }
         public DbSet<CheckList> CheckLists { get; set; }



    }
}
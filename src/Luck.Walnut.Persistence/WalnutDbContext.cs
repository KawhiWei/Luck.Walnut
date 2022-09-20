using Luck.EntityFrameworkCore.DbContexts;
using Luck.Walnut.Domain.AggregateRoots.Applications;
using Luck.Walnut.Domain.AggregateRoots.Environments;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Luck.Walnut.Domain.AggregateRoots.Assignments;
using Luck.Walnut.Domain.AggregateRoots.Matters;
using Luck.Walnut.Domain.AggregateRoots.Projects;

namespace Luck.Walnut.Persistence
{
    public class WalnutDbContext : LuckDbContextBase
    {
        public WalnutDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options, serviceProvider)
        {
        }

        public DbSet<AppConfiguration> AppConfigurations => Set<AppConfiguration>();


        public DbSet<AppEnvironment> AppEnvironments => Set<AppEnvironment>();

        public DbSet<Application> Applications => Set<Application>();
        
        
        public DbSet<Project> Projects => Set<Project>();
        
        public DbSet<Issue> Issues => Set<Issue>();
        
        public DbSet<Assignment> Assignments => Set<Assignment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("luck.walnut");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

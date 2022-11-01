using System.Reflection;
using Luck.EntityFrameworkCore.DbContexts;
using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;
using Luck.Walnut.Domain.AggregateRoots.Applications;
using Luck.Walnut.Domain.AggregateRoots.Assignments;
using Luck.Walnut.Domain.AggregateRoots.ComponentIntegrations;
using Luck.Walnut.Domain.AggregateRoots.Environments;
using Luck.Walnut.Domain.AggregateRoots.Issues;
using Luck.Walnut.Domain.AggregateRoots.Languages;
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
        
        public DbSet<Language> Languages => Set<Language>();
        
        public DbSet<ComponentIntegration> ComponentIntegrations => Set<ComponentIntegration>();
        
        public DbSet<ApplicationPipeline> ApplicationPipelines => Set<ApplicationPipeline>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("luck.walnut");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

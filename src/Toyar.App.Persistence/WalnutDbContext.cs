using System.Reflection;
using Luck.EntityFrameworkCore.DbContexts;
using Toyar.App.Domain.AggregateRoots.Pipelines;
using Toyar.App.Domain.AggregateRoots.Applications;
using Toyar.App.Domain.AggregateRoots.ComponentIntegrations;
using Toyar.App.Domain.AggregateRoots.Environments;
using Toyar.App.Domain.AggregateRoots.ContinuousIntegrationImages;

namespace Toyar.App.Persistence
{
    public class WalnutDbContext : LuckDbContextBase
    {
        public WalnutDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options, serviceProvider)
        {
        }

        public DbSet<Application> Applications => Set<Application>();

        public DbSet<AppConfiguration> Configurations => Set<AppConfiguration>();

        public DbSet<AppEnvironment> Environments => Set<AppEnvironment>();

        

        public DbSet<ComponentIntegration> ComponentIntegrations => Set<ComponentIntegration>();

        public DbSet<Pipeline> Pipelines => Set<Pipeline>();

        public DbSet<PipelineHistory> PipelineHistories => Set<PipelineHistory>();

        public DbSet<ContinuousIntegrationImage> ContinuousIntegrationImages => Set<ContinuousIntegrationImage>();

        public DbSet<ContinuousIntegrationImageVersion> CIRunnerImageVersions => Set<ContinuousIntegrationImageVersion>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("toyar.app");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
using System.Reflection;
using Luck.EntityFrameworkCore.DbContexts;
using Toyar.App.Domain.AggregateRoots.Pipelines;
using Toyar.App.Domain.AggregateRoots.Applications;
using Toyar.App.Domain.AggregateRoots.ComponentIntegrations;
using Toyar.App.Domain.AggregateRoots.Environments;
using Toyar.App.Domain.AggregateRoots.ContinuousIntegrationImages;
using Toyar.App.Domain.AggregateRoots.Templates;

namespace Toyar.App.Persistence
{
    public class ToyarDbContext : LuckDbContextBase
    {
        public ToyarDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options, serviceProvider)
        {
        }

        public DbSet<Application> Applications => Set<Application>();

        public DbSet<AppConfiguration> Configurations => Set<AppConfiguration>();

        public DbSet<AppEnvironment> Environments => base.Set<AppEnvironment>();

        public DbSet<ComponentIntegration> ComponentIntegrations => Set<ComponentIntegration>();

        public DbSet<ApplicationPipeline> Pipelines => Set<ApplicationPipeline>();

        public DbSet<PipelineHistory> PipelineHistories => Set<PipelineHistory>();

        public DbSet<ContinuousIntegrationImage> ContinuousIntegrationImages => Set<ContinuousIntegrationImage>();

        public DbSet<ContinuousIntegrationImageVersion> CIRunnerImageVersions => Set<ContinuousIntegrationImageVersion>();

        public DbSet<PipelineTemplate> PipelineTemplates => Set<PipelineTemplate>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("toyar.app");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
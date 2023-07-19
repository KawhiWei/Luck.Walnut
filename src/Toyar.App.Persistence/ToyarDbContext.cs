using System.Reflection;
using Luck.EntityFrameworkCore.DbContexts;
using Toyar.App.Domain.AggregateRoots.Pipelines;
using Toyar.App.Domain.AggregateRoots.Applications;
using Toyar.App.Domain.AggregateRoots.ComponentIntegrations;
using Toyar.App.Domain.AggregateRoots.Environments;
using Toyar.App.Domain.AggregateRoots.ContinuousIntegrationImages;
using Toyar.App.Domain.AggregateRoots.Templates;
using Toyar.App.Domain.AggregateRoots.K8s.Clusters;
using Toyar.App.Domain.AggregateRoots.K8s.NameSpaces;
using Toyar.App.Domain.AggregateRoots.K8s.Services;
using Toyar.App.Domain.AggregateRoots.Deployments;
using Luck.Walnut.Kube.Domain.AggregateRoots.SideCar;

namespace Toyar.App.Persistence
{
    public class ToyarDbContext : LuckDbContextBase
    {
        public ToyarDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options, serviceProvider)
        {
        }

        public DbSet<Application> Applications => Set<Application>();

        public DbSet<AppConfiguration> Configurations => Set<AppConfiguration>();

        public DbSet<ToyarEnvironment> ToyarEnvironments => base.Set<ToyarEnvironment>();

        public DbSet<ComponentIntegration> ComponentIntegrations => Set<ComponentIntegration>();

        public DbSet<ApplicationPipeline> Pipelines => Set<ApplicationPipeline>();

        public DbSet<PipelineHistory> PipelineHistories => Set<PipelineHistory>();

        public DbSet<ContinuousIntegrationImage> ContinuousIntegrationImages => Set<ContinuousIntegrationImage>();

        public DbSet<ContinuousIntegrationImageVersion> CIRunnerImageVersions => Set<ContinuousIntegrationImageVersion>();

        public DbSet<PipelineTemplate> PipelineTemplates => Set<PipelineTemplate>();

        public DbSet<SideCarPlugin> SideCarPlugins => Set<SideCarPlugin>();

        public DbSet<Cluster> Clusters => Set<Cluster>();

        public DbSet<NameSpace> NameSpaces => Set<NameSpace>();

        public DbSet<Service> Services => Set<Service>();

        public DbSet<Deployment> Deployments => Set<Deployment>();

        public DbSet<DeploymentContainer> DeploymentContainers => Set<DeploymentContainer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("toyar.app");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
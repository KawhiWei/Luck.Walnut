using System.Reflection;
using Luck.EntityFrameworkCore.DbContexts;
using Toyar.App.Domain.AggregateRoots.ApplicationPipelines;
using Toyar.App.Domain.AggregateRoots.Applications;
using Toyar.App.Domain.AggregateRoots.ComponentIntegrations;
using Toyar.App.Domain.AggregateRoots.Environments;
using Toyar.App.Domain.AggregateRoots.ContinuousIntegrationImages;
using Toyar.App.Domain.AggregateRoots.Templates;
using Toyar.App.Domain.AggregateRoots.K8s.Clusters;
using Toyar.App.Domain.AggregateRoots.K8s.NameSpaces;
using Toyar.App.Domain.AggregateRoots.K8s.Services;
using Luck.Walnut.Kube.Domain.AggregateRoots.SideCar;
using Toyar.App.Domain.AggregateRoots.KubernetesOperationHistories;
using Toyar.App.Domain.AggregateRoots.K8s.WorkLoads;
using Toyar.App.Domain.AggregateRoots.SideCarPlugins;

namespace Toyar.App.Persistence
{
    public class ToyarDbContext : LuckDbContextBase
    {
        public ToyarDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options, serviceProvider)
        {
        }

        public DbSet<Application> Applications => Set<Application>();
        
        public DbSet<ToyarEnvironment> ToyarEnvironments => base.Set<ToyarEnvironment>();

        public DbSet<ComponentIntegration> ComponentIntegrations => Set<ComponentIntegration>();

        public DbSet<ApplicationPipeline> Pipelines => Set<ApplicationPipeline>();

        public DbSet<ApplicationPipelineHistory> PipelineHistories => Set<ApplicationPipelineHistory>();

        public DbSet<ContinuousIntegrationImage> ContinuousIntegrationImages => Set<ContinuousIntegrationImage>();

        public DbSet<ContinuousIntegrationImageVersion> ContinuousIntegrationImageVersions => Set<ContinuousIntegrationImageVersion>();

        public DbSet<KubernetesOperationHistory> KubernetesOperationHistories => Set<KubernetesOperationHistory>();


        
        public DbSet<PipelineTemplate> PipelineTemplates => Set<PipelineTemplate>();

        public DbSet<SideCarPlugin> SideCarPlugins => Set<SideCarPlugin>();

        public DbSet<Cluster> Clusters => Set<Cluster>();

        public DbSet<NameSpace> NameSpaces => Set<NameSpace>();

        public DbSet<Service> Services => Set<Service>();

        public DbSet<WorkLoad> WorkLoads => Set<WorkLoad>();

        public DbSet<WorkLoadContainer> WorkLoadContainers => Set<WorkLoadContainer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("toyar.app");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
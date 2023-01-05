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
using Luck.Walnut.Domain.AggregateRoots.BuildImages;
using BuildImage = Luck.Walnut.Domain.AggregateRoots.BuildImages.BuildImage;

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

        public DbSet<BuildImage> RunImages => Set<BuildImage>();

        public DbSet<BuildImageVersion> RunImageVersions => Set<BuildImageVersion>();

        public DbSet<ApplicationPipelineExecutedRecord> ApplicationPipelineExecutedRecords => Set<ApplicationPipelineExecutedRecord>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("luck.walnut");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
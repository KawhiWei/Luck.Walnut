using System.Reflection;
using Luck.EntityFrameworkCore.DbContexts;
using Toyar.Domain.AggregateRoots.ToyarApplications;
using Toyar.Domain.AggregateRoots.ToyarBaseComponents;
using Toyar.Domain.AggregateRoots.ToyarEnvironments;
using Toyar.Domain.AggregateRoots.ToyarRoles;


namespace Toyar.Persistence
{
    public class ToyarDbContext : LuckDbContextBase
    {
        public ToyarDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ToyarApplication> ToyarApplications => Set<ToyarApplication>();

        public DbSet<ToyarApplicationDeploymentConfiguration> ToyarApplicationDeploymentConfigurations =>
            Set<ToyarApplicationDeploymentConfiguration>();

        public DbSet<ToyarApplicationEnvironmentRelation> ToyarApplicationEnvironmentRelations =>
            Set<ToyarApplicationEnvironmentRelation>();

        public DbSet<ToyarApplicationPermissionRelation> ToyarApplicationPermissionRelations =>
            Set<ToyarApplicationPermissionRelation>();

        public DbSet<ToyarBaseComponent> ToyarBaseComponents => Set<ToyarBaseComponent>();

        public DbSet<ToyarEnvironment> ToyarEnvironments => Set<ToyarEnvironment>();

        public DbSet<ToyarRole> ToyarRoles => Set<ToyarRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("toyar_infra");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
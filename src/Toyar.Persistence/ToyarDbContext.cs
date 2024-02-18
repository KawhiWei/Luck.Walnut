using System.Reflection;
using Luck.EntityFrameworkCore.DbContexts;


namespace Toyar.Persistence
{
    public class ToyarDbContext : LuckDbContextBase
    {
        public ToyarDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options, serviceProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("toyar.app");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
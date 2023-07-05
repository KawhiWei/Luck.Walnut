using Toyar.App.Domain.AggregateRoots.Environments;

namespace Toyar.App.Persistence
{
    public class AppEnvironmentMapConfiguration : IEntityTypeConfiguration<AppEnvironment>
    {
        public void Configure(EntityTypeBuilder<AppEnvironment> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name);
            builder.HasIndex(x => x.Name, "name_unique_index")
                .IsUnique();
            builder.ToTable("app_environments");
        }
    }
}
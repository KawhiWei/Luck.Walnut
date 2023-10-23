using Toyar.App.Domain.AggregateRoots.Environments;

namespace Toyar.App.Persistence.Configurations
{
    public class ToyarEnvironmentMapConfiguration : IEntityTypeConfiguration<ToyarEnvironment>
    {
        public void Configure(EntityTypeBuilder<ToyarEnvironment> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name);
            builder.HasIndex(x => x.Name, "name_unique_index")
                .IsUnique();
            builder.ToTable("toyar_environments");
        }
    }
}
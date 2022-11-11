using Luck.Walnut.Domain.AggregateRoots.ComponentIntegrations;

namespace Luck.Walnut.Persistence.Configurations;

public class ComponentIntegrationConfiguration : IEntityTypeConfiguration<ComponentIntegration>
{
    public void Configure(EntityTypeBuilder<ComponentIntegration> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Credential).HasJsonConversion().HasColumnName("credential");;
        builder.ToTable("component_integrations");
    }
}
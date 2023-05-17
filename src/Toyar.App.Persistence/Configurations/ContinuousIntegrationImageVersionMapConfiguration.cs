using Toyar.App.Domain.AggregateRoots.ContinuousIntegrationImages;

namespace Toyar.App.Persistence.Configurations;

public class ContinuousIntegrationImageVersionMapConfiguration: IEntityTypeConfiguration<ContinuousIntegrationImageVersion>
{
    public void Configure(EntityTypeBuilder<ContinuousIntegrationImageVersion> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Version,"version_unique_index")
            .IsUnique();
        builder.ToTable("continuous_integration_image_versions");
    }
}
using Toyar.App.Domain.AggregateRoots.ContinuousIntegrationImages;

namespace Toyar.App.Persistence.Configurations;

public class ContinuousIntegrationImageMapConfiguration : IEntityTypeConfiguration<ContinuousIntegrationImage>
{
    public void Configure(EntityTypeBuilder<ContinuousIntegrationImage> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(o => o.ContinuousIntegrationImageVersions)
            .WithOne()
            .HasForeignKey(x => x.ContinuousIntegrationImageId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.Name, "name_unique_index")
            .IsUnique();
        builder.ToTable("continuous_integration_images");
    }
}
using Luck.Walnut.Domain.AggregateRoots.BuildImages;

namespace Luck.Walnut.Persistence.Configurations;

public class BuildImageVersionMapConfiguration: IEntityTypeConfiguration<BuildImageVersion>
{
    public void Configure(EntityTypeBuilder<BuildImageVersion> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Version,"version_unique_index")
            .IsUnique();
        builder.ToTable("build_image_versions");
    }
}
using Luck.Walnut.Domain.AggregateRoots.BuildImages;

namespace Luck.Walnut.Persistence.Configurations;

public class BuildImageMapConfiguration : IEntityTypeConfiguration<BuildImage>
{
    public void Configure(EntityTypeBuilder<BuildImage> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(o => o.RunImageVersions)
            .WithOne()
            .HasForeignKey(x => x.BuildImageId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.Name, "name_unique_index")
            .IsUnique();
        builder.ToTable("build_images");
    }
}
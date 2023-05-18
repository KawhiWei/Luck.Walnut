using Toyar.App.Domain.AggregateRoots.Pipelines;

namespace Toyar.App.Persistence.Configurations;

public class PipelineMapConfiguration : IEntityTypeConfiguration<Pipeline>
{
    public void Configure(EntityTypeBuilder<Pipeline> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.PipelineScript).HasJsonConversion();
        builder.HasMany(o => o.PipelineHistories)
            .WithOne()
            .HasForeignKey(x => x.PipelineId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.ToTable("pipelines");
    }
}


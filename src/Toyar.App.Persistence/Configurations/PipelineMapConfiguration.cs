using Toyar.App.Domain.AggregateRoots.Pipelines;

namespace Toyar.App.Persistence.Configurations;

public class PipelineMapConfiguration : IEntityTypeConfiguration<ApplicationPipeline>
{
    public void Configure(EntityTypeBuilder<ApplicationPipeline> builder)
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


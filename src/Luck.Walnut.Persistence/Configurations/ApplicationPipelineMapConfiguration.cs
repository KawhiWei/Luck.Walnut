using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;

namespace Luck.Walnut.Persistence.Configurations;

public class ApplicationPipelineMapConfiguration : IEntityTypeConfiguration<ApplicationPipeline>
{
    public void Configure(EntityTypeBuilder<ApplicationPipeline> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.PipelineScript).HasJsonConversion();
        builder.HasMany(o => o.ApplicationPipelineExecutedRecords)
            .WithOne()
            .HasForeignKey(x => x.ApplicationPipelineId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.ToTable("application_pipelines");
    }
}
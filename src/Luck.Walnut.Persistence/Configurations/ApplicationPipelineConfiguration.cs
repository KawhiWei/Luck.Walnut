using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;

namespace Luck.Walnut.Persistence.Configurations;

public class ApplicationPipelineConfiguration: IEntityTypeConfiguration<ApplicationPipeline>
{
    public void Configure(EntityTypeBuilder<ApplicationPipeline> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.PipelineScript).HasJsonConversion();
        builder.ToTable("application_pipelines");
    }
}
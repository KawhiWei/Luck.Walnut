using Toyar.App.Domain.AggregateRoots.ApplicationPipelines;

namespace Toyar.App.Persistence.Configurations;

public class ApplicationPipelineMapConfiguration : IEntityTypeConfiguration<ApplicationPipeline>
{
    public void Configure(EntityTypeBuilder<ApplicationPipeline> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.PipelineScript)!.HasJsonConversion();
        builder.Property(e => e.PipelineParameters)!.HasJsonConversion();
        builder.Property(x => x.CreateUser).HasDefaultValue("");
        builder.Property(x => x.LastModificationUser).HasDefaultValue("");
        builder.HasMany(o => o.PipelineHistories)
            .WithOne()
            .HasForeignKey(x => x.PipelineId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.ToTable("application_pipelines");
    }
}

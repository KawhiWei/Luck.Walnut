using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;

namespace Luck.Walnut.Persistence.Configurations;


public class ApplicationPipelineExecutedRecordMapConfiguration : IEntityTypeConfiguration<ApplicationPipelineExecutedRecord>
{
    public void Configure(EntityTypeBuilder<ApplicationPipelineExecutedRecord> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PipelineScript).HasJsonConversion();
        //////todo 不这样，当Remove时候，会把AppEnvironmentId清空
        //builder.Property<string>("AppEnvironmentId").IsRequired().HasMaxLength(95);
        // builder.HasIndex(x => new { x.Key, x.Value });
        builder.ToTable("application_pipeline_executed_records");
    }
}
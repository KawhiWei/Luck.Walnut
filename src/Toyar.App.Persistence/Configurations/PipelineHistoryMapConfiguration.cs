using Toyar.App.Domain.AggregateRoots.Pipelines;

namespace Toyar.App.Persistence.Configurations;


public class PipelineHistoryMapConfiguration : IEntityTypeConfiguration<PipelineHistory>
{
    public void Configure(EntityTypeBuilder<PipelineHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PipelineScript).HasJsonConversion();
        //////todo 不这样，当Remove时候，会把AppEnvironmentId清空
        //builder.Property<string>("AppEnvironmentId").IsRequired().HasMaxLength(95);
        // builder.HasIndex(x => new { x.Key, x.Value });
        builder.ToTable("pipeline_histories");
    }
}
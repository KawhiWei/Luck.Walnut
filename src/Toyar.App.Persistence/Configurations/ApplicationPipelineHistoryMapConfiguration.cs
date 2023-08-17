using Toyar.App.Domain.AggregateRoots.ApplicationPipelines;

namespace Toyar.App.Persistence.Configurations;


public class ApplicationPipelineHistoryMapConfiguration : IEntityTypeConfiguration<ApplicationPipelineHistory>
{
    public void Configure(EntityTypeBuilder<ApplicationPipelineHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PipelineScript).HasJsonConversion();
        builder.Property(x => x.CreateUser).HasDefaultValue("");
        builder.Property(x => x.LastModificationUser).HasDefaultValue("");
        //////todo 不这样，当Remove时候，会把AppEnvironmentId清空
        //builder.Property<string>("AppEnvironmentId").IsRequired().HasMaxLength(95);
        // builder.HasIndex(x => new { x.Key, x.Value });
        builder.ToTable("application_pipeline_histories");
    }
}
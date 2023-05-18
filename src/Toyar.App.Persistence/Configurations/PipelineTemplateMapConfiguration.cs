using Toyar.App.Domain.AggregateRoots.Pipelines;
using Toyar.App.Domain.AggregateRoots.Templates;

namespace Toyar.App.Persistence.Configurations;

public class PipelineTemplateMapConfiguration : IEntityTypeConfiguration<PipelineTemplate>
{
    public void Configure(EntityTypeBuilder<PipelineTemplate> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.PipelineScript).HasJsonConversion();
        builder.ToTable("pipeline_templates");
    }
}


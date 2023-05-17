using Toyar.App.Domain.AggregateRoots.Issues;

namespace Toyar.App.Persistence.Configurations;

public class IssueMapConfiguration: IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.ToTable("issues");
        builder.HasKey(e => e.Id);
        builder.HasKey(e => e.Id);
        builder.Property(e => e.ProductManagers).HasJsonConversion();

    }
}
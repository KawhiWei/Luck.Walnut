using Luck.EntityFrameworkCore.Extensions;
using Luck.Walnut.Domain.AggregateRoots.Issues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Luck.Walnut.Persistence.Configurations;

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
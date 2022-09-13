using Luck.EntityFrameworkCore.Extensions;
using Luck.Walnut.Domain.AggregateRoots.Matters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Luck.Walnut.Persistence.Configurations;

public class MatterMapConfiguration: IEntityTypeConfiguration<Matter>
{
    public void Configure(EntityTypeBuilder<Matter> builder)
    {
        builder.ToTable("matters");
        builder.HasKey(e => e.Id);
        builder.HasKey(e => e.Id);
        builder.Property(e => e.ProductManagers).HasJsonConversion();

    }
}
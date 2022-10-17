using Luck.Walnut.Domain.AggregateRoots.Assignments;

namespace Luck.Walnut.Persistence.Configurations;

/// <summary>
/// 
/// </summary>
public class AssignmentMapConfiguration: IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.ToTable("assignments");
        builder.HasKey(e => e.Id);
    }
}
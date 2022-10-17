using Luck.Walnut.Domain.AggregateRoots.Projects;

namespace Luck.Walnut.Persistence.Configurations;

public class ProjectMapConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("projects");
    }
}
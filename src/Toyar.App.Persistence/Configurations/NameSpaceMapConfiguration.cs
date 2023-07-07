using Toyar.App.Domain.AggregateRoots.K8s.NameSpaces;

namespace Toyar.App.Persistence.Configurations;

/// <summary>
/// 命名空间配置
/// </summary>
public class NameSpaceMapConfiguration : IEntityTypeConfiguration<NameSpace>
{
    public void Configure(EntityTypeBuilder<NameSpace> builder)
    {
        builder.HasKey(e => e.Id);
        builder.ToTable("namespaces");
    }
}

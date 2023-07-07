using Toyar.App.Domain.AggregateRoots.K8s.Clusters;

namespace Toyar.App.Persistence.Configurations;

/// <summary>
/// 集群管理配置
/// </summary>
public class ClusterMapConfiguration : IEntityTypeConfiguration<Cluster>
{
    public void Configure(EntityTypeBuilder<Cluster> builder)
    {
        builder.HasKey(e => e.Id);
        builder.ToTable("clusters");
    }
}

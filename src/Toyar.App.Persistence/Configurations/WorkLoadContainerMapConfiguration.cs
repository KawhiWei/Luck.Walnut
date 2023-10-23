using Toyar.App.Domain.AggregateRoots.K8s.WorkLoads;

namespace Toyar.App.Persistence.Configurations;

/// <summary>
/// 部署容器配置
/// </summary>

public class WorkLoadContainerMapConfiguration : IEntityTypeConfiguration<WorkLoadContainer>
{
    public void Configure(EntityTypeBuilder<WorkLoadContainer> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.ContainerPlugins)!.HasJsonConversion();
        builder.Property(x => x.CreateUser).HasDefaultValue("");
        builder.Property(x => x.LastModificationUser).HasDefaultValue("");
        builder.ToTable("workload_containers");
    }
}

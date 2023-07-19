using Toyar.App.Domain.AggregateRoots.Deployments;

namespace Toyar.App.Persistence.Configurations;

/// <summary>
/// 部署容器配置
/// </summary>

public class DeploymentContainerMapConfiguration : IEntityTypeConfiguration<DeploymentContainer>
{
    public void Configure(EntityTypeBuilder<DeploymentContainer> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.ContainerPlugins).HasJsonConversion();
        builder.ToTable("deployment_containers");
    }
}

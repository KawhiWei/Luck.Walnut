using Toyar.App.Domain.AggregateRoots.K8s.Deployments;

namespace Toyar.App.Persistence.Configurations;

/// <summary>
/// 部署容器配置
/// </summary>

public class DeploymentContainerMapConfiguration : IEntityTypeConfiguration<DeploymentContainer>
{
    public void Configure(EntityTypeBuilder<DeploymentContainer> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.ReadinessProbe).HasJsonConversion();
        builder.Property(e => e.LiveNessProbe).HasJsonConversion();
        builder.Property(e => e.Limits).HasJsonConversion();
        builder.Property(e => e.Requests).HasJsonConversion();
        builder.Property(e => e.Environments).HasJsonConversion();
        builder.Property(e => e.ContainerPortConfigurations).HasJsonConversion();
        builder.ToTable("deployment_containers");
    }
}
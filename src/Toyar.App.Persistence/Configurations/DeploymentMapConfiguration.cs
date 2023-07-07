using Toyar.App.Domain.AggregateRoots.K8s.Deployments;

namespace Toyar.App.Persistence.Configurations;

/// <summary>
/// 部署基础配置
/// </summary>
public class DeploymentMapConfiguration : IEntityTypeConfiguration<Deployment>
{
    public void Configure(EntityTypeBuilder<Deployment> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasMany(o => o.Containers)
            .WithOne()
            .HasForeignKey(x => x.DeploymentId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(e => e.SideCars).HasJsonConversion();
        builder.Property(e => e.Strategy).HasJsonConversion();
        builder.HasIndex(x => x.AppId, "appid_unique_index");
        builder.ToTable("deployments");
    }
}

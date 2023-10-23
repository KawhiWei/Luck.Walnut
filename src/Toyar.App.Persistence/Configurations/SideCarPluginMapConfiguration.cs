using Luck.Walnut.Kube.Domain.AggregateRoots.SideCar;
using Toyar.App.Domain.AggregateRoots.SideCarPlugins;

namespace Toyar.App.Persistence.Configurations;

/// <summary>
/// SideCarPlugin容器配置
/// </summary>

public class SideCarPluginMapConfiguration : IEntityTypeConfiguration<SideCarPlugin>
{
    public void Configure(EntityTypeBuilder<SideCarPlugin> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.ContainerPlugins).HasJsonConversion();
        builder.ToTable("sidecar_plugins");
    }
}
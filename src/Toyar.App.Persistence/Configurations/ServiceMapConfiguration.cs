using Toyar.App.Domain.AggregateRoots.K8s.Services;

namespace Toyar.App.Persistence.Configurations;

/// <summary>
/// 命名空间配置
/// </summary>
public class ServiceMapConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.ServicePorts).HasJsonConversion();
        builder.ToTable("services");
    }
}

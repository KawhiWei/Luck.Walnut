using Toyar.App.Domain.AggregateRoots.KubernetesOperationHistories;

namespace Toyar.App.Persistence.Configurations;

/// <summary>
/// K8s操作记录
/// </summary>
public class KubernetesOperationHistoryMapConfiguration : IEntityTypeConfiguration<KubernetesOperationHistory>
{
    public void Configure(EntityTypeBuilder<KubernetesOperationHistory> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(x => x.CreateUser).HasDefaultValue("");
        builder.ToTable("kubernetes_operation_histories");
    }
}
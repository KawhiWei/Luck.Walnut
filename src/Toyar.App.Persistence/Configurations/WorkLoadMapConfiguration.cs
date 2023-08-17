using Toyar.App.Domain.AggregateRoots.WorkLoads;

namespace Toyar.App.Persistence.Configurations;

/// <summary>
/// 部署基础配置
/// </summary>
public class WorkLoadMapConfiguration : IEntityTypeConfiguration<WorkLoad>
{
    public void Configure(EntityTypeBuilder<WorkLoad> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasMany(o => o.Containers)
            .WithOne()
            .HasForeignKey(x => x.DeploymentId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(e => e.SideCars)!.HasJsonConversion();
        builder.Property(e => e.DeploymentPlugins)!.HasJsonConversion();
        builder.HasIndex(x => x.AppId, "appid_unique_index");
        builder.Property(x => x.CreateUser).HasDefaultValue("");
        builder.Property(x => x.LastModificationUser).HasDefaultValue("");
        builder.ToTable("workloads");
    }
}

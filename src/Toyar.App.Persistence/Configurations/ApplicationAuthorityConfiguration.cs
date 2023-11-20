using Toyar.App.Domain.AggregateRoots.Applications;
using Toyar.App.Domain.AggregateRoots.Authorities;

namespace Toyar.App.Persistence.Configurations;

/// <summary>
/// 应用权限关联关系
/// </summary>
public class ApplicationAuthorityConfiguration : IEntityTypeConfiguration<Authority>
{
    public void Configure(EntityTypeBuilder<Authority> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(x => x.CreateUser).HasDefaultValue("");
        builder.Property(x => x.LastModificationUser).HasDefaultValue("");
        builder.HasIndex(x => x.EnvironmentId, "environment_id_unique_index");
        builder.HasIndex(x => x.UserId, "user_id_unique_index");
        builder.ToTable("application_authorities");
    }
}
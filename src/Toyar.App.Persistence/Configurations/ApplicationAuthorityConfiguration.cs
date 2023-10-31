using Toyar.App.Domain.AggregateRoots.Applications;

namespace Toyar.App.Persistence.Configurations;

public class ApplicationAuthorityConfiguration : IEntityTypeConfiguration<ApplicationAuthority>
{
    public void Configure(EntityTypeBuilder<ApplicationAuthority> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(x => x.CreateUser).HasDefaultValue("");
        builder.Property(x => x.LastModificationUser).HasDefaultValue("");
        
        builder.HasIndex(x => x.EnvironmentId,"environment_id_unique_index")
            .IsUnique();
        builder.HasIndex(x => x.UserId,"user_id_unique_index")
            .IsUnique();
        builder.ToTable("application_authorities");
    }
}
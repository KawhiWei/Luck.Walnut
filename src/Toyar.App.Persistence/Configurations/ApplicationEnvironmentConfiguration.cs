using Toyar.App.Domain.AggregateRoots.Applications;

namespace Toyar.App.Persistence.Configurations;

public class ApplicationEnvironmentConfiguration : IEntityTypeConfiguration<ApplicationEnvironment>
{
    public void Configure(EntityTypeBuilder<ApplicationEnvironment> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(x => x.CreateUser).HasDefaultValue("");
        builder.Property(x => x.LastModificationUser).HasDefaultValue("");
        builder.HasIndex(x => x.EnvironmentId,"user_id_unique_index")
            .IsUnique();
        builder.ToTable("application_environments");
    }
}
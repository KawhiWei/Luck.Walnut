using Toyar.App.Domain.AggregateRoots.Roles;

namespace Toyar.App.Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(x => x.CreateUser).HasDefaultValue("");
        builder.Property(x => x.LastModificationUser).HasDefaultValue("");
        builder.HasIndex(x => x.Name,"name_unique_index")
            .IsUnique();
        builder.HasIndex(x => x.Id,"id_unique_index")
            .IsUnique();
        builder.ToTable("roles");
    }
}
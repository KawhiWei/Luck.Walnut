using Toyar.Domain.AggregateRoots.ToyarEnvironments;

namespace Toyar.Persistence.Configurations;

public class ToyarEnvironmentConfiguration : IEntityTypeConfiguration<ToyarEnvironment>
{
    public void Configure(EntityTypeBuilder<ToyarEnvironment> builder)
    {
        builder.ToTable("toyar_environment");
        builder.HasKey(e => e.Id);
        builder.Property(x => x.EnglishName).HasColumnName("english_name");
        builder.Property(x => x.ChinesName).HasColumnName("chines_name");
        builder.Property(x => x.IsSystemDefault).HasColumnName("is_system_default");
        builder.Property(x => x.CreateUserName).HasColumnName("create_user_name");
        builder.Property(x => x.CreateUserId).HasColumnName("create_user_id");
        builder.Property(x => x.CreationTime).HasColumnName("creation_time");
        builder.Property(x => x.LastModificationUserName).HasColumnName("last_modification_user_name");
        builder.Property(x => x.LastModificationUserId).HasColumnName("last_modification_user_id");
        builder.Property(x => x.LastModificationTime).HasColumnName("last_modification_time");
        builder.Property(x => x.DeletionTime).HasColumnName("deletion_time");
    }
}
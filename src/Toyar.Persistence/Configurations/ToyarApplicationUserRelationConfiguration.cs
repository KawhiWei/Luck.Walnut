using Toyar.Domain.AggregateRoots.ToyarApplications;

namespace Toyar.Persistence.Configurations;

public class ToyarApplicationUserRelationConfiguration : IEntityTypeConfiguration<ToyarApplicationUserRelation>
{
    public void Configure(EntityTypeBuilder<ToyarApplicationUserRelation> builder)
    {
        builder.ToTable("toyar_application_user_relation");
        builder.HasKey(e => e.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.UserId).HasColumnName("user_id");
        builder.Property(x => x.AppId).HasColumnName("app_id");
        builder.Property(x => x.CreateUserName).HasColumnName("create_user_name");
        builder.Property(x => x.CreateUserId).HasColumnName("create_user_id");
        builder.Property(x => x.CreationTime).HasColumnName("creation_time");
        builder.Property(x => x.LastModificationUserName).HasColumnName("last_modification_user_name");
        builder.Property(x => x.LastModificationUserId).HasColumnName("last_modification_user_id");
        builder.Property(x => x.LastModificationTime).HasColumnName("last_modification_time");
        builder.Property(x => x.DeletionTime).HasColumnName("deletion_time");
    }
}
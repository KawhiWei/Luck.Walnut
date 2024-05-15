using Toyar.Domain.AggregateRoots.ToyarApps;

namespace Toyar.Persistence.Configurations;

public class ToyarAppConfiguration : IEntityTypeConfiguration<ToyarApp>
{
    public void Configure(EntityTypeBuilder<ToyarApp> builder)
    {
        builder.ToTable("toyar_app");
        builder.HasKey(e => e.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.AppId).HasColumnName("app_id");
        builder.Property(x => x.AppName).HasColumnName("app_name");
        builder.Property(x => x.ModuleGit).HasColumnName("module_git");
        builder.Property(x => x.AppType).HasColumnName("app_type");
        builder.Property(x => x.OwnedUser).HasColumnName("owned_user");
        builder.Property(x => x.DeployType).HasColumnName("deploy_type");
        builder.Property(x => x.AppDeployStatusType).HasColumnName("app_deploy_status_type");
        builder.Property(x => x.Note).HasColumnName("note");
        builder.Property(x => x.IsUseDeployTemplate).HasColumnName("is_use_deploy_template");
        builder.Property(x => x.CreateUserName).HasColumnName("create_user_name");
        builder.Property(x => x.CreateUserId).HasColumnName("create_user_id");
        builder.Property(x => x.CreationTime).HasColumnName("creation_time");
        builder.Property(x => x.LastModificationUserName).HasColumnName("last_modification_user_name");
        builder.Property(x => x.LastModificationUserId).HasColumnName("last_modification_user_id");
        builder.Property(x => x.LastModificationTime).HasColumnName("last_modification_time");
        builder.Property(x => x.DeletionTime).HasColumnName("deletion_time");

        builder.HasMany(o => o.ToyarAppUserRelations)
            .WithOne()
            .HasForeignKey(x => x.AppId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
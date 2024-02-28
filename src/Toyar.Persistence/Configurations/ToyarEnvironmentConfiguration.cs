using Toyar.Domain.AggregateRoots.Environments;

namespace Toyar.Persistence.Configurations;

public class ToyarEnvironmentConfiguration: IEntityTypeConfiguration<ToyarEnvironment>
{
    public void Configure(EntityTypeBuilder<ToyarEnvironment> builder)
    {
        #region 属性

        builder.HasKey(e => e.Id);
        builder.Property(x => x.CreateUserName).HasDefaultValue("");
        builder.Property(x => x.LastModificationUserName).HasDefaultValue("");
        builder.Property(x => x.LastModificationUserId).HasDefaultValue("");
        
        #endregion

        #region 索引

        builder.HasIndex(x => x.CreateUserId, "idx_create_user_id");
        builder.HasIndex(x => x.LastModificationUserId, "idx_last_modification_user_id");

        #endregion

        builder.ToTable("toyar_environment");
    }
    
}
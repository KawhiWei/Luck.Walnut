using Toyar.Domain.AggregateRoots.ToyarBaseComponents;

namespace Toyar.Persistence.Configurations;

public class ToyarBaseComponentEfConfiguration : IEntityTypeConfiguration<ToyarBaseComponent>
{
    public void Configure(EntityTypeBuilder<ToyarBaseComponent> builder)
    {
        builder.ToTable("toyar_base_component");
        builder.HasKey(e => e.Id);
        builder.Property(x => x.EnglishName).HasColumnName("english_name");
        builder.Property(x => x.ChinesName).HasColumnName("chines_name");
        builder.Property(x => x.Url).HasColumnName("url");
        builder.Property(x => x.CertificateType).HasColumnName("certificate_type");
        builder.Property(x => x.Token).HasColumnName("token");
        builder.Property(x => x.Account).HasColumnName("account");
        builder.Property(x => x.Password).HasColumnName("password");
        builder.Property(x => x.CreateUserName).HasColumnName("create_user_name");
        builder.Property(x => x.CreateUserId).HasColumnName("create_user_id");
        builder.Property(x => x.CreationTime).HasColumnName("creation_time");
        builder.Property(x => x.LastModificationUserName).HasColumnName("last_modification_user_name");
        builder.Property(x => x.LastModificationUserId).HasColumnName("last_modification_user_id");
        builder.Property(x => x.LastModificationTime).HasColumnName("last_modification_time");
        builder.Property(x => x.DeletionTime).HasColumnName("deletion_time");
    }
}
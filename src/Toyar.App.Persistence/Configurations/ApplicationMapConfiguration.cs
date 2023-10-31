using Toyar.App.Domain.AggregateRoots.Applications;

namespace Toyar.App.Persistence.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.AppId);
            builder.Property(x => x.CreateUser).HasDefaultValue("");
            builder.Property(x => x.LastModificationUser).HasDefaultValue("");

            #region 导航属性
            builder.HasMany(o => o.ApplicationEnvironments)
                .WithOne()
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasMany(o => o.ApplicationAuthorities)
                .WithOne()
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region 索引
            builder.HasIndex(x => x.AppId,"appId_unique_index")
                .IsUnique();
            #endregion

            builder.ToTable("applications");
        }
    }
}

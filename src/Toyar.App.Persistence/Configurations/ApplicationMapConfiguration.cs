using Toyar.App.Domain.AggregateRoots.Applications;

namespace Toyar.App.Persistence
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.AppId);
            builder.Property(x => x.CreateUser).HasDefaultValue("");
            builder.Property(x => x.LastModificationUser).HasDefaultValue("");
            builder.Property(e => e.Environments)!.HasJsonConversion();
            builder.HasIndex(x => x.AppId,"appId_unique_index")
                .IsUnique();
            builder.ToTable("applications");
        }
    }
}

using Toyar.App.Domain.AggregateRoots.Applications;

namespace Toyar.App.Persistence
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.AppId);
            builder.HasIndex(x => x.AppId,"appId_unique_index")
                .IsUnique();
            builder.ToTable("applications");
        }
    }
}

using Luck.Walnut.Domain.AggregateRoots.Applications;

namespace Luck.Walnut.Persistence
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.EnglishName);
            builder.Property(e => e.DepartmentName);
            builder.Property(e => e.ChineseName);
            builder.Property(e => e.Principal).IsRequired(false);
            builder.Property(e => e.AppId);
            builder.Property(e => e.ImageWarehouse).HasJsonConversion();
            builder.Property(e => e.BuildImage).HasJsonConversion();
            builder.HasIndex(x => x.AppId,"appId_unique_index")
                .IsUnique();
            builder.ToTable("applications");
        }
    }
}

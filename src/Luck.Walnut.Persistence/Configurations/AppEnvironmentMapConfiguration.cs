using Luck.Walnut.Domain.AggregateRoots.Environments;

namespace Luck.Walnut.Persistence
{
    public class AppEnvironmentMapConfiguration : IEntityTypeConfiguration<AppEnvironment>
    {
        public void Configure(EntityTypeBuilder<AppEnvironment> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.EnvironmentName);
            builder.Property(e => e.AppId).HasMaxLength(95);

            builder.HasMany(o => o.Configurations)
                .WithOne()
                .HasForeignKey(x => x.AppEnvironmentId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasIndex(x => x.EnvironmentName,"environmentName_unique_index")
                .IsUnique();
            builder.ToTable("environments");
        }
    }
}
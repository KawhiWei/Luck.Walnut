using Toyar.App.Domain.AggregateRoots.Languages;

namespace Toyar.App.Persistence.Configurations;

public class LanguageMapConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Name,"name_unique_index")
            .IsUnique();
        builder.ToTable("languages");
    }
}
using Luck.Walnut.Domain.AggregateRoots.Languages;

namespace Luck.Walnut.Persistence.Configurations;

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
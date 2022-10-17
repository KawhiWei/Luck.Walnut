﻿using Luck.Walnut.Domain.AggregateRoots.Environments;

namespace Luck.Walnut.Persistence.Configurations
{
    public class AppConfigurationMapConfiguration : IEntityTypeConfiguration<AppConfiguration>
    {
        public void Configure(EntityTypeBuilder<AppConfiguration> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Key);
            builder.Property(x => x.Value);
            builder.Property(x => x.Type);
            builder.Property(x => x.IsOpen);
            builder.Property(x => x.IsPublish);
            builder.Property(x => x.Group);
            //////todo 不这样，当Remove时候，会把AppEnvironmentId清空
            //builder.Property<string>("AppEnvironmentId").IsRequired().HasMaxLength(95);
            // builder.HasIndex(x => new { x.Key, x.Value });
            builder.ToTable("configurations");
        }
    }
}
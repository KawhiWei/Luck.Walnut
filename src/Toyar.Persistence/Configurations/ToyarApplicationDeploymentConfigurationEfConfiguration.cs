using Toyar.Domain.AggregateRoots.ToyarApplications;

namespace Toyar.Persistence.Configurations;

public class
    ToyarApplicationDeploymentConfigurationEfConfiguration : IEntityTypeConfiguration<
    ToyarApplicationDeploymentConfiguration>
{
    public void Configure(EntityTypeBuilder<ToyarApplicationDeploymentConfiguration> builder)
    {
        builder.ToTable("toyar_application_deployment_configuration");
        builder.HasKey(e => e.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.EnvironmentId).HasColumnName("environment_id");
        builder.Property(x => x.HealthCheckMode).HasColumnName("health_check_mode");
        builder.Property(x => x.HealthCheckUrl).HasColumnName("health_check_url");
        builder.Property(x => x.ReleaseStrategy).HasColumnName("release_strategy");
        builder.Property(x => x.ServicePort)!.HasJsonConversion().HasColumnName("service_port");
        builder.Property(x => x.BotNotificationType).HasColumnName("bot_notification_type");
        builder.Property(x => x.BotNotificationUrl).HasColumnName("bot_notification_url");
        builder.Property(x => x.DeploymentBeforeWebHookUrl).HasColumnName("deployment_before_web_hook_url");
        builder.Property(x => x.DeploymentAfterWebHookUrl).HasColumnName("deployment_after_web_hook_url");
        builder.Property(x => x.RestartPolicy).HasColumnName("restart_policy");
        builder.Property(x => x.Cpu).HasColumnName("cpu");
        builder.Property(x => x.ContainerPattern).HasColumnName("container_pattern");
        builder.Property(x => x.EnvironmentVariable)!.HasJsonConversion().HasColumnName("environment_variable");
        builder.Property(x => x.Mounts)!.HasJsonConversion().HasColumnName("mounts");

        builder.Property(x => x.IsDefaultDeployment).HasColumnName("is_default_deployment");
        builder.Property(x => x.CreateUserName).HasColumnName("create_user_name");
        builder.Property(x => x.CreateUserId).HasColumnName("create_user_id");
        builder.Property(x => x.CreationTime).HasColumnName("creation_time");
        builder.Property(x => x.LastModificationUserName).HasColumnName("last_modification_user_name");
        builder.Property(x => x.LastModificationUserId).HasColumnName("last_modification_user_id");
        builder.Property(x => x.LastModificationTime).HasColumnName("last_modification_time");
        builder.Property(x => x.DeletionTime).HasColumnName("deletion_time");
    }
}
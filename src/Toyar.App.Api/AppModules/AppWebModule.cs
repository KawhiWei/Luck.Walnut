using Luck.AppModule;
using Luck.AutoDependencyInjection;
using Luck.Framework.Infrastructure;


namespace Toyar.App.Api.AppModules
{
    [DependsOn(
        typeof(AutoDependencyAppModule),
        typeof(EntityFrameworkCoreModule),
        typeof(MigrationModule),
        typeof(SerilogModule),
        typeof(EntityFrameworkCoreModule)
    )]


    public class AppWebModule : LuckAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddHttpClient();
            base.ConfigureServices(context);

        }
    }
}

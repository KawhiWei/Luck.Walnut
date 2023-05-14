using Luck.Framework.Infrastructure;


namespace Luck.Walnut.Api.AppModules
{
    [DependsOn(
        typeof(DependencyAppModule),
        typeof(EntityFrameworkCoreModule),
        typeof(MigrationModule),
        typeof(SerilogModule),
        typeof(EntityFrameworkCoreModule)
    )]
    
    
    public class AppWebModule: AppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddHttpClient();
            base.ConfigureServices(context);
            
        }
    }
}

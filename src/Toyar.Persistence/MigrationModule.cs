using Luck.AppModule;
using Luck.Framework.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Toyar.Persistence
{
    [DependsOn(
        typeof(EntityFrameworkCoreModule)
    )]
    public class MigrationModule : LuckAppModule

    {
        //SELECT pg_terminate_backend(pg_stat_activity.pid) FROM pg_stat_activity WHERE datname = 'toyar.app' AND pid<>pg_backend_pid();
        //SQL删除    drop schema "toyar.app" cascade;
        public override void ApplicationInitialization(ApplicationContext context)
        {
           
        }
    }
}
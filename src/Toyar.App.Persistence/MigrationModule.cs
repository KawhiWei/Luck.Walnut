using Luck.Framework.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Toyar.App.Persistence
{
    [DependsOn(
        typeof(EntityFrameworkCoreModule)
    )]
    public class MigrationModule : AppModule
    {
        //SQL删除    drop schema "toyar.app" cascade;
        public override void ApplicationInitialization(ApplicationContext context)
        {
            var moduleDbContext = context.ServiceProvider.GetService<WalnutDbContext>();
            if (moduleDbContext == null) return;
            var isExist = moduleDbContext.Database.EnsureCreated();

            moduleDbContext.SaveChanges();
        }



        
    }
}
using Luck.AppModule;
using Luck.Framework.Infrastructure;
using Serilog;
using Serilog.Events;

namespace Toyar.App.Api.AppModules
{
    public class SerilogModule : LuckAppModule
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddLogging(builder =>
            {

                Log.Logger = new LoggerConfiguration()

                   .Enrich.FromLogContext()
                   .WriteTo.Console()
                      .WriteTo.File(Path.Combine("Logs", @$"{DateTime.Now.ToString("yyyy-MM-dd")}", "log.log"))
                      .CreateLogger();

                builder.AddSerilog();
            });

        }


    }
}

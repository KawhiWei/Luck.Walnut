using Toyar.App.AppService.Pipelines;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Toyar.App.AppService.BackgroundServices;

public class JenkinsExecutedRecordSyncBackgroundService : BackgroundService
{
    private readonly IServiceProvider _rootServiceProvider;
    private readonly ILogger<JenkinsExecutedRecordSyncBackgroundService> _logger;

    public JenkinsExecutedRecordSyncBackgroundService(IServiceProvider rootServiceProvider, ILogger<JenkinsExecutedRecordSyncBackgroundService> logger)
    {
        _rootServiceProvider = rootServiceProvider;
        _logger = logger;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (true)
        {
            using (var scope = _rootServiceProvider.CreateScope())
            {
                var applicationPipelineService = scope.ServiceProvider.GetRequiredService<IPipelineService>();
                try
                {
                    await applicationPipelineService.SyncExecutedRecordAsync();
                }
                catch (Exception e)
                {
                    _logger.LogError("同步Jenkins执行记录异常-------------{EMessage}", e.Message);
                }
            }

            await Task.Delay(5000, stoppingToken);
        }
    }
}
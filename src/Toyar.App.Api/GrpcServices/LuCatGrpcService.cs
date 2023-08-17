using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Toyar.App.Api.Protos;
using Toyar.App.AppService.Environments;

namespace Toyar.App.Api.GrpcServices;

[AutoMapGrpcService]
public class LuCatGrpcService : LuCat.LuCatBase 
{
    private readonly ILogger<LuCatGrpcService> _logger;
    private readonly IApplactionClientConcurrentQueue _applactionClientConcurrentQueue;
    private readonly ITest _test;

    public LuCatGrpcService(IApplactionClientConcurrentQueue applactionClientConcurrentQueue,
        ILogger<LuCatGrpcService> logger, ITest test)
    {
        _applactionClientConcurrentQueue = applactionClientConcurrentQueue;
        _logger = logger;
        _test = test;
    }

    /// <summary>
    /// 发起链接
    /// </summary>
    /// <param name="requestStream"></param>
    /// <param name="responseStream"></param>
    /// <param name="context"></param>
    public override async Task BathTheCat(IAsyncStreamReader<BathTheCatReq> requestStream,
        IServerStreamWriter<BathTheCatResp> responseStream, ServerCallContext context)
    {
        while (await requestStream.MoveNext())
        {
            //将要洗澡的猫加入队列
            Console.WriteLine($"Cat {requestStream.Current.Id} Enqueue.");
        }

        var clientId = Guid.NewGuid().ToString();
        _test.AddResponseStream("test", clientId, responseStream, context);
        context.CancellationToken.Register(() => { _test.RemoveResponseStream("test", clientId); });
        while (!context.CancellationToken.IsCancellationRequested)
        {
            await Task.Delay(1000);
        }
        // ReSharper disable once FunctionNeverReturns
    }

    public override Task<CountCatResult> Count(Empty request, ServerCallContext context)
    {
        return Task.FromResult(new CountCatResult()
        {
            Count = 80
        });
    }
}
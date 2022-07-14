using System.Collections.Concurrent;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Luck.Walnut.Api.Protos;
using Luck.Walnut.Application;
using Luck.Walnut.Application.Environments;
using Luck.Walnut.Application.Environments.Events;
using MediatR;

namespace Luck.Walnut.Api.GrpcServices;

[AutoMapGrpcService]
public class LuCatGrpcService : LuCat.LuCatBase, INotificationHandler<AppConfigurationEvent>
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
        while (true)
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

    public async Task Handle(AppConfigurationEvent notification, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // var conn = _test.GetResponseStream("test");
        // if (conn is not null)
        // {
        //     try
        //     {
        //         if (conn.Value.responseStream is not null)
        //         {
        //             if (conn.Value.context.CancellationToken.IsCancellationRequested)
        //             {
        //                 await conn.Value.responseStream.WriteAsync(new BathTheCatResp()
        //                     { Message = $"铲屎的成功给一只[{notification.AppId}+{Guid.NewGuid()}]洗了澡！" });
        //             }
        //         }
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e);
        //         throw;
        //     }
        // }
    }
}
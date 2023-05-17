using System.Collections.Concurrent;
using Grpc.Core;
using Luck.Framework.Infrastructure.DependencyInjectionModule;
using Toyar.App.Api.Protos;

namespace Toyar.App.Api.GrpcServices;

public class Test : ITest
{
    private readonly ConcurrentDictionary<string, List<ClientRequestDto>> _bathTheCatRespConcurrentDictionary =
        new ConcurrentDictionary<string, List<ClientRequestDto>>();

    public void AddResponseStream(string appId, string clientId, IServerStreamWriter<BathTheCatResp> responseStream,
        ServerCallContext context)
    {
        var clients = new List<ClientRequestDto>();
        var client = new ClientRequestDto(responseStream, context, clientId);
        if (_bathTheCatRespConcurrentDictionary.ContainsKey(appId))
        {
            clients = _bathTheCatRespConcurrentDictionary[appId];
            clients.Add(client);
        }
        else
        {
            clients.Add(client);
            _bathTheCatRespConcurrentDictionary.TryAdd(appId, clients);
        }
    }

    public List<ClientRequestDto>? GetResponseStream(string appId)
    {
        if (_bathTheCatRespConcurrentDictionary.TryGetValue(appId, out var clients))
        {
            return clients;
        }

        ;
        return null;
    }
    
    public void  RemoveResponseStream(string appId, string clientId)
    {
        if (_bathTheCatRespConcurrentDictionary.TryGetValue(appId, out var clients))
        {
            var client=clients.FirstOrDefault(x => x.ClientId == clientId);
            if (client is not null)
            {
                clients.Remove(client);
            }
        }
    }
}

public interface ITest : ISingletonDependency
{
    void AddResponseStream(string appId, string clientId, IServerStreamWriter<BathTheCatResp> responseStream,
        ServerCallContext context);

    List<ClientRequestDto>? GetResponseStream(string appId);


    void RemoveResponseStream(string appId, string clientId);
}

public class ClientRequestDto
{
    public ClientRequestDto(IServerStreamWriter<BathTheCatResp> responseStream, ServerCallContext context,
        string clientId)
    {
        ResponseStream = responseStream;
        Context = context;
        ClientId = clientId;
    }

    /// <summary>
    /// 服务端主动发送消息的请求留
    /// </summary>
    public IServerStreamWriter<BathTheCatResp> ResponseStream { get; private set; } = default!;


    /// <summary>
    /// 客户端链接
    /// </summary>
    public ServerCallContext Context { get; private set; } = default!;

    /// <summary>
    /// 客户端链接唯一标识
    /// </summary>
    public string ClientId { get; private set; } = default!;
}
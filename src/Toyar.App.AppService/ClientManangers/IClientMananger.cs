using System.Collections.Concurrent;
using Toyar.App.AppService.Environments.Events;

namespace Toyar.App.AppService;

public interface IClientMananger:ISingletonDependency
{
    void Add(string appId,string connectionId);
    
    List<string> GetConnectionIds(string appId);
}
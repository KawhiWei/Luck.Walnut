using System.Collections.Concurrent;

namespace Toyar.App.AppService.Environments;

public interface IApplactionClientConcurrentQueue:ISingletonDependency
{
    ConcurrentQueue<string> ConcurrentQueue { get; }
}
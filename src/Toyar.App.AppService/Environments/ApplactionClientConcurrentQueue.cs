using System.Collections.Concurrent;

namespace Toyar.App.AppService.Environments;

public class ApplactionClientConcurrentQueue : IApplactionClientConcurrentQueue
{
    public ApplactionClientConcurrentQueue()
    {
        ConcurrentQueue = new ConcurrentQueue<string>();
    }

    public ConcurrentQueue<string> ConcurrentQueue { get; }
    public void Add(string message)
    {
        ConcurrentQueue.Enqueue(message);
    }
}
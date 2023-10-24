using System.Collections.Concurrent;

namespace Start.Demos.ScopeDemo.CustomScope.CustomScopeComponents
{
    public class CrawlingWorkerState
    {
        public string? WorkingAddress { get; set; }
        public bool IsIdle { get; set; }

        public int PagesCrawled = 0;

        public string? WorkerName { get; set; }

        public ConcurrentQueue<string> AddressesToCrawl { get; } = new ();
    }
}

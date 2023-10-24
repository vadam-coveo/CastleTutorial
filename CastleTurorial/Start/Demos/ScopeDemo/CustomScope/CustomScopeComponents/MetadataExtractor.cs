using Start.Demos.ScopeDemo.CommonComponents;
using Start.Loggers;
using System.Net;

namespace Start.Demos.ScopeDemo.CustomScope.CustomScopeComponents
{
    public interface IMetadataExtractor
    {
        string ExtractMetadata(string address);
        IEnumerable<string> ExtractUrls(string address);
        string Name { get; }
    }

    public interface IMetadataExtractorFactory
    {
        IMetadataExtractor CreateExtractor();
        void Release(IMetadataExtractor extractor);
    }

    public class MetadataExtractor : IMetadataExtractor, IDisposable
    {
        private CrawlingWorkerState State { get; }
        private IStartingAddress StartingAddress { get; }

        public string Name => $"Extractor for {State.WorkerName}";

        public MetadataExtractor(CrawlingWorkerState state, IStartingAddress startingAddress, ILogger logger)
        {
            State = state;
            StartingAddress = startingAddress;
        }

        public string ExtractMetadata(string address)
        {
            return $"'{State.WorkerName}' crawled {State.PagesCrawled} pages so far, working on address '{address}', starting starting address scope is '{StartingAddress.Address}', discovered from starting address = '{StartingAddress.DiscoveredAddresses.Count}'";
        }

        public IEnumerable<string> ExtractUrls(string address)
        {
            if (NoFutherUrlsToExtract(address))
                return Enumerable.Empty<string>();

            var children = GenerateChildAddresses(address);
            foreach (var child in children)
            {
                State.AddressesToCrawl.Enqueue(child);
                StartingAddress.DiscoveredAddresses.Add(child);
            }

            return children;
        }

        private IEnumerable<string> GenerateChildAddresses(string address)
        {
            return new List<string>
            {
                $"{address}/A-{State.PagesCrawled}",
                $"{address}/B-{State.PagesCrawled}",
            };
        }

        private bool NoFutherUrlsToExtract(string address)
        {
            return address.Count(x => x == '/') > 1;
        }

        public void Dispose()
        {
        }
    }
}

using Start.Loggers;
using Start.StuffForHelping;
using System.Collections.Concurrent;

namespace Start.Demos.ScopeDemo.CustomScope.CustomScopeComponents
{
    public interface ICrawlingService
    {
        void Crawl(string url);
    }

    public class CrawlingService : BaseComponent, ICrawlingService
    {
        public IMetadataExtractorFactory MetadataExtractorFactory { get; }
        private ICrawlingJob CrawlingJob { get; }
        public CrawlingService(IMetadataExtractorFactory metadataExtractorFactory, ICrawlingJob crawlingJob, ILogger logger) : base(logger)
        {
            MetadataExtractorFactory = metadataExtractorFactory;
            CrawlingJob = crawlingJob;
        }

        public void Crawl(string url)
        {
            var extractor = MetadataExtractorFactory.CreateExtractor();

            try
            {
                CrawlingJob.AddAddress(url);

                Logger.LogLogic(extractor.ExtractMetadata(url));

                var urls = extractor.ExtractUrls(url);
                
                if (urls.Any())
                {
                    Logger.LogLessRelevantStuff($"{extractor.Name} found urls {string.Join(", ", url)}");
                }
                else
                {
                    Logger.LogLessRelevantStuff($"{extractor.Name} -------> didn't find any urls");
                }
                
            }
            finally
            {
                MetadataExtractorFactory.Release(extractor);
            }
        }
    }
}

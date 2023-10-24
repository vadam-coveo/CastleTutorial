using Start.Demos.ScopeDemo.CommonComponents;
using Start.Demos.ScopeDemo.CustomScope.CustomScopeUtils;
using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.ScopeDemo.CustomScope.CustomScopeComponents
{
    public class CrawlingWorker : BaseComponent, ICrawlingWorker
    {
        private IAbstractFactory AbstractFactory { get; }
        private ICrawlingService CrawlingService { get; }
        public CrawlingWorkerState CrawlingWorkerState { get; }

        public CrawlingWorker(ILogger logger, ICrawlingService crawlingService, IAbstractFactory abstractFactory, CrawlingWorkerState crawlingWorkerState) : base(logger)
        {
            CrawlingService = crawlingService;
            AbstractFactory = abstractFactory;
            CrawlingWorkerState = crawlingWorkerState;
            CrawlingWorkerState.IsIdle = false;
        }

        public void StartCrawling(string startingAddress)
        {
            CrawlingWorkerState.AddressesToCrawl.Enqueue(startingAddress);

            using (var scope = new CustomLogicalScope<StartingAddress>())
            {
                var startingAddressClass = AbstractFactory.CreateStartingAddress(startingAddress);

                while (CrawlingWorkerState.AddressesToCrawl.TryDequeue(out var address))
                {
                    DoCrawl(address);
                }

                Logger.LogLessRelevantStuff($"------------->{CrawlingWorkerState.WorkerName} is done with starting address '{startingAddressClass.Address}', it crawled so far : {CrawlingWorkerState.PagesCrawled} urls");

            }
        }

        private void DoCrawl(string address)
        {
            CrawlingWorkerState.WorkingAddress = address;
            CrawlingService.Crawl(address);
            CrawlingWorkerState.PagesCrawled++;
        }
    }
}

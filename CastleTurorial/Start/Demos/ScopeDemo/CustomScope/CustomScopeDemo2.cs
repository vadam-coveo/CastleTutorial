using Start.Demos.ScopeDemo.CommonComponents;
using Start.Demos.ScopeDemo.CustomScope.CustomScopeComponents;
using Start.Demos.ScopeDemo.CustomScope.CustomScopeUtils;
using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.ScopeDemo.CustomScope
{
    public class CustomScopeDemo2 : BaseComponent, ICanBeDemoed
    {
        private IAbstractFactory AbstractFactory { get; }
        private ICrawlingJob CrawlingJob { get; }

        public CustomScopeDemo2(ILogger logger, IAbstractFactory factory, ICrawlingJob crawlingJob) : base(logger)
        {
            AbstractFactory = factory;
            CrawlingJob = crawlingJob;
        }

        [Obsolete]
        public void Demo()
        {
            var task1 = new Action(() => CrawlAddresses(1, "Address1", "Address2"));
            //var task2 = new Action(() => CrawlAddresses(2, "Address3", "Address4"));

            Parallel.Invoke(task1);

            Logger.LogLogic($"Crawled a total of {CrawlingJob.GetAllDiscoveredAddresses().Count()} addresses");
        }

        [Obsolete]
        private void CrawlAddresses(int workerId, params string[] startingAddresses)
        {
            var crawlingWorkerScope = new CustomLogicalScope<CrawlingWorker>();

            var worker = AbstractFactory.CreateCrawlingWorker();
            worker.CrawlingWorkerState.WorkerName = $"worker {workerId}";

            foreach (var startingAddress in startingAddresses)
            {
                worker.StartCrawling(startingAddress);
            }

            crawlingWorkerScope.Dispose();
        }
    }
}

namespace Start.Demos.ScopeDemo.CustomScope.CustomScopeComponents;

public interface ICrawlingWorker
{
    CrawlingWorkerState CrawlingWorkerState { get; }
    void StartCrawling(string startingAddress);
}
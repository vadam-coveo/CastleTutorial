using Start.Demos.ScopeDemo.CustomScope.CustomScopeComponents;

namespace Start.Demos.ScopeDemo.CommonComponents
{
    public interface IAbstractFactory
    {
        public IStartingAddress CreateStartingAddress(string startingAddress);

        public IComponentPerStartingAddress ResolveComponentForStartingAddress();

        public ICrawlingWorker CreateCrawlingWorker();
    }
}

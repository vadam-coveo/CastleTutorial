using Start.Demos.ScopeDemo.CommonComponents;
using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.ScopeDemo.SimpleScope
{
    public class SimpleScopeDemo : BaseComponent, ICanBeDemoed
    {
        public IComponentFactory ComponentFactory { get; }
        public ScopeProvider ScopeProvider { get; }

        private IComponentPerStartingAddress component1;

        public SimpleScopeDemo(IComponentFactory componentFactory, ILogger logger, ScopeProvider scopeProvider) : base(logger)
        {
            ComponentFactory = componentFactory;
            ScopeProvider = scopeProvider;
        }

        public void Demo()
        {
            var scope1 = ScopeProvider.BeginScope();

            var startingAddress1 = ComponentFactory.CreateStartingAddress("patate");
            Logger.LogLogic($"Created scope {startingAddress1.Address}");
            component1 = ComponentFactory.ResolveComponentForStartingAddress();

            Logger.LogLogic($"Created {component1}");
            TryAgain();


            var scope2 = ScopeProvider.BeginScope();

            var startingAddress = ComponentFactory.CreateStartingAddress("otherpatate");
            Logger.LogLogic($"Created scope {startingAddress.Address}");
            var component = ComponentFactory.ResolveComponentForStartingAddress();
            Logger.LogLogic($"Created {component}");
            scope2.Dispose();


            TryAgain();
            scope1.Dispose();

        }

        private void TryAgain()
        {
            var component11 = ComponentFactory.ResolveComponentForStartingAddress();
            Logger.LogLogic($"Tryed resolving component1 again :  {component11} ");

            if (component1.ComponentId != component11.ComponentId)
            {
                Logger.Error($"Didn't get the same compoenent {component1.ComponentId}!");
            }
        }
    }
}

using Start.Demos.ScopeDemo.CommonComponents;
using Start.Demos.ScopeDemo.CustomScope.CustomScopeUtils;
using Start.Loggers;
using Start.StuffForHelping;


namespace Start.Demos.ScopeDemo.CustomScope
{
    internal class CustomScopeDemo : BaseComponent, ICanBeDemoed
    {
        public IComponentFactory ComponentFactory { get; }
        private IComponentPerStartingAddress component1;
        private ScopeProvider ScopeProvider;
        public CustomScopeDemo(ILogger logger, IComponentFactory componentFactory, ScopeProvider scopeProvider) : base(logger)
        {
            ComponentFactory = componentFactory;
            ScopeProvider = scopeProvider;
        }

        [Obsolete]
        public void Demo()
        {
            Logger.LogLogic($"++++++++++  Creating new starting address scope1 patate");
            var scope1 = new CustomLogicalScope<StartingAddress>();

            ComponentFactory.CreateStartingAddress("patate");
            component1 = ComponentFactory.ResolveComponentForStartingAddress();
            Logger.LogLessRelevantStuff($"Created new component per starting address : {component1}");

            TryAgain();
            TryAgain();

            Logger.LogLogic($"++++++++++  Creating new starting address scope2 (nested within scope1) otherpatate");
            var scope2 = new CustomLogicalScope<StartingAddress>();

            ComponentFactory.CreateStartingAddress("otherpatate");
            var component2 = ComponentFactory.ResolveComponentForStartingAddress();
            Logger.LogLessRelevantStuff($"Created new component per starting address : {component2}");
            var component22 = ComponentFactory.ResolveComponentForStartingAddress();

            Logger.LogLogic($"Component 2 resolved twice within context 2 are equal = {component22.ComponentId == component2.ComponentId}");


            Logger.LogLogic($"---------  Disposing scope2 (nested within scope1) otherpatate");
            scope2.Dispose();

            TryAgain();
            TryAgain();

            var thread = new Task(() =>
            {
                Logger.LogLogic($"++++++++++  From within the task");
                var scope3 = new CustomLogicalScope<CustomScopeDemoInstaller>();
                TryAgain(true);
                scope3.Dispose();
            });
            thread.Start();

            Logger.LogLogic($"++++++++++  Creating new un-named scope");
            var otherScope = new CustomLogicalScope<CustomScopeDemo>();
            TryAgain();
            TryAgain();

            Logger.LogLogic($"---------  Disposing scope1 patate");

            thread.Wait();

            scope1.Dispose();

            Logger.LogLogic($"---------  Disposing un-named scope");
            otherScope.Dispose();
        }

        private void TryAgain(bool isInTask = false)
        {
            var component11 = ComponentFactory.ResolveComponentForStartingAddress();

            if (!isInTask)
            {
                Logger.LogLessRelevantStuff($"**** resolving from scope 1 : worked again!  {component11}");
            }
            else
            {
                Logger.LogLogic($"**** resolving from scope 1 : worked again!  {component11}");
            }

            if (component1.ComponentId != component11.ComponentId)
            {
                Logger.Error($"Didn't get the same compoenent {component1.ComponentId}!");
            }
        }
    }
}

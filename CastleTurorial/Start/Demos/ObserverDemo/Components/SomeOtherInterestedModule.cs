using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.ObserverDemo.Components
{
    public class SomeOtherInterestedModule : BaseComponent, ISomeOtherInterestedModule
    {

        public SomeOtherInterestedModule(ILogger logger) : base(logger)
        {
        }

        public void OnChange(ObservableComponent observable)
        {
            Logger.LogLogic($"SomeOtherInterestedModule module {this} onchange was invoked, total is {observable.Total}");
        }
    }
}

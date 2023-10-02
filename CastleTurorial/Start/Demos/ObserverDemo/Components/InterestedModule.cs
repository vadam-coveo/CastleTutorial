using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.ObserverDemo.Components
{
    public class InterestedModule : BaseComponent, IInterestedModule
    {
        public InterestedModule(ILogger logger) : base(logger)
        {
        }

        public void OnChange(ObservableComponent observable)
        {
            Logger.LogLogic($"Interested module {this} onchange was invoked, total is {observable.Total}");
        }
    }
}

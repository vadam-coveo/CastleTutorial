using Start.Demos.ObserverDemo.Components;
using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.ObserverDemo
{
    public class ObserverDemo : BaseComponent, ICanBeDemoed
    {
        public IInterestedModule Module { get; }
        public IEnumerable<ISomeOtherInterestedModule> Othermodules { get; }

        public IObservableComponent ObservableComponent { get; }

        public ObserverDemo(ILogger logger, IObservableComponent observableComponent, IInterestedModule module, IEnumerable<ISomeOtherInterestedModule> othermodules) : base(logger)
        {
            ObservableComponent = observableComponent;
            Module = module;
            Othermodules = othermodules;
        }

        public void Demo()
        {
            ObservableComponent.Increment(1);

            Logger.LogLessRelevantStuff("---------------------------------------------------------------------");

            ObservableComponent.Increment(10);

            Logger.LogLessRelevantStuff("---------------------------------------------------------------------");

            ObservableComponent.Increment(100);

            Logger.LogLessRelevantStuff("---------------------------------------------------------------------");

            ObservableComponent.Decrement(100);

        }
    }
}

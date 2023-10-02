using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.ObserverDemo.Components
{
    public class ObservableComponent : BaseComponent, IObservableComponent
    {
        public int Total { get; internal set; } = 0;

        public ObservableComponent(ILogger logger) : base(logger)
        {
        }

        public void Increment(int value)
        {
            Total += value;
        }

        public void Decrement(int value)
        {
            Total -= value;
        }
    }
}

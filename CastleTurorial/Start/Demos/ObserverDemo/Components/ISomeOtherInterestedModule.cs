using Start.Demos.ObserverDemo.Framework;

namespace Start.Demos.ObserverDemo.Components;

public interface ISomeOtherInterestedModule : IObservee<ObservableComponent>
{
}
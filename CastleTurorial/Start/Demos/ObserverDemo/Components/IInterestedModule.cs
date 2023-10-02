using Start.Demos.ObserverDemo.Framework;

namespace Start.Demos.ObserverDemo.Components;

public interface IInterestedModule : IObservee<ObservableComponent>
{
}
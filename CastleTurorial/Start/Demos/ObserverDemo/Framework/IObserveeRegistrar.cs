namespace Start.Demos.ObserverDemo.Framework;

public interface IObserveeRegistrar<TObservable> where TObservable : class
{
    void Register(IObservee<TObservable> observee);
    void Unregister(IObservee<TObservable> observee);
    IList<IObservee<TObservable>> GetAll();
}
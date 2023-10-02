namespace Start.Demos.ObserverDemo.Components;

public interface IObservableComponent
{
    int Total { get; }
    void Increment(int value);
    void Decrement(int value);
    string ToString();
    void Dispose();
}
namespace Start.Demos.ObserverDemo.Framework
{
    public interface IObservee<TObservable> where TObservable : class
    {
        public void OnChange(TObservable observable);
    }
}

using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.ObserverDemo.Framework
{
    public class ObserveeRegistrar<TObservable> : BaseComponent, IObserveeRegistrar<TObservable>
        where TObservable : class
    {
        public List<IObservee<TObservable>> Registrations = new List<IObservee<TObservable>>();

        public ObserveeRegistrar(ILogger logger) : base(logger)
        {
        }

        public void Register(IObservee<TObservable> observee)
        {
            Logger.LogLessRelevantStuff($"Registering observee {observee}");
            Registrations.Add(observee);
        }

        public void Unregister(IObservee<TObservable> observee)
        {
            Logger.LogLessRelevantStuff($"UnRegistering observee {observee}");
            Registrations.Remove(observee);
        }

        public IList<IObservee<TObservable>> GetAll()
        {
            return Registrations.ToList();
        }


    }
}

using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.TypedFactoryDemo
{
    public class TypedFactoryDemo : BaseComponent, ICanBeDemoed, IDisposable
    {
        private IExampleTypedServiceFactory ServiceFactory { get; }

        public TypedFactoryDemo(IExampleTypedServiceFactory serviceFactory, ILogger logger) : base(logger)
        {
            ServiceFactory = serviceFactory;
        }

        public void Demo()
        {
            SampleSingleCreation();
        }

        public void SampleSingleCreation()
        {
            var poco = new SamplePoco();

            Logger.LogLogic("Trying to spawn an instance of a service based on a poco");

            var instance = ServiceFactory.Resolve(poco, poco);

            Logger.LogLogic($"Got instance {instance}");

            instance.PerformAction();

            Logger.LogLogic($"Releasing {instance} back to the factory");
            ServiceFactory.Release(instance);

            Logger.LogLogic($"Calling Release on the service factory");
            ServiceFactory.Dispose();
        }
    }
}

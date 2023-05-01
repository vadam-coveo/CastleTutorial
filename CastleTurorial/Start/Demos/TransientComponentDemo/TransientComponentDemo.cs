using Start.Loggers;

namespace Start.Demos.TransientComponentDemo
{
    public class TransientComponentDemo : ICanBeDemoed
    {
        private ILogger Logger { get; }
        private ISingletonService Service1 { get; }

        private ITransientService TransientService { get; }

        public TransientComponentDemo(ISingletonService service1, ITransientService transientService, ILogger logger)
        {
            Logger = logger;
            TransientService = transientService;
            Service1 = service1;
        }

        public void Demo()
        {
            if(Service1.TransientServiceInstance.GetGuid == TransientService.GetGuid)
                Logger.Error("Uh oh, we expected the transient service to be transient!");
            else
                Logger.LogLogic("Service 1 and service 2 have different instances of the transient service");


            if (ReferenceEquals(Service1.LoggerInstance, Logger))
                Logger.LogLogic("The logger has no lifestyle specified, therefore it's singleton by default, hence all services will be passed with the same instance");
            else
                Logger.Error("Uh oh, we expected the logger to be a singleton!");
        }
    }
}

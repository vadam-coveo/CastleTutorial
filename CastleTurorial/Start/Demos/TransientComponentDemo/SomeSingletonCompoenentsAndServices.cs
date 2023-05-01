using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.TransientComponentDemo
{
    public interface ISingletonService
    {
        ILogger LoggerInstance { get; }
        ITransientService TransientServiceInstance { get; }
    }

  
    public class SingletonService : BaseComponent, ISingletonService
    {
        public ILogger LoggerInstance => Logger;
        public ITransientService TransientServiceInstance { get; }
        public SingletonService(ITransientService service, ILogger logger) : base(logger)
        {
            TransientServiceInstance = service;
        }
    }
}


using Start.Loggers;

namespace Start.StuffForHelping
{
    public class BaseComponent
    {
        public Guid Guid = Guid.NewGuid();
        protected ILogger Logger { get; }

        public BaseComponent(ILogger logger)
        {
            Logger = logger;
            Logger.LogLifecycleEvent($"+++ Constructor called on {this}");
        }

        ~BaseComponent()
        {
            Logger.LogLifecycleEvent($"--- Destructor called on {this}");
        }

        public override string ToString()
        {
            var type = GetType();
            return $"{type.Name} with id {Guid}";
        }

        public void Dispose()
        {
            Logger.LogLessRelevantStuff($"Called dispose on {this}");
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}

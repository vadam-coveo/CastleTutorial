using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.Challenge.Application
{
    public class DatabaseConnection : BaseComponent, IDatabaseConnection
    {
        private IDatabaseConfiguration Configuration { get;}

        public DatabaseConnection(IDatabaseConfiguration configuration, ILogger logger) : base(logger)
        {
            Configuration = configuration;
        }

        public string GetConnectionName()
        {
            return Configuration?.ConnectionName ?? "Un-named connection";
        }

        public virtual string GetInstanceName()
        {
            return $"{GetConnectionName()} + {Guid}";
        }
    }
}

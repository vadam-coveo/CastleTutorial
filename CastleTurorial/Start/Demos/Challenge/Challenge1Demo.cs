using Start.Demos.Challenge.Application;
using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.Challenge
{
    public class Challenge1Demo : BaseComponent, ICanBeDemoed
    {
        private readonly IList<IDatabaseConfiguration> _configs;

        public Challenge1Demo(IList<IDatabaseConfiguration> configs, ILogger logger) : base(logger)
        {
            _configs = configs;
        }
        public void Demo()
        {
            foreach (var databaseConfiguration in _configs)
            {
                Logger.LogLogic(databaseConfiguration.ConnectionName);
            }
        }
    }
}

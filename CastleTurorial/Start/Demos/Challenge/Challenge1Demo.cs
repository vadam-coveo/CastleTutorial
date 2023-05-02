using Start.Demos.Challenge.Application;
using Start.Demos.Challenge.Application.Paypal;
using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.Challenge
{
    public class Challenge1Demo : BaseComponent, ICanBeDemoed
    {
        private readonly IList<IDatabaseConfiguration> _configs;
        private readonly IConnectionCollector _connectionCollector;
        private readonly ISpecialElonMuskTreatment _elonMuskTreatment;

        public Challenge1Demo(IList<IDatabaseConfiguration> configs, IConnectionCollector connectionCollector, ISpecialElonMuskTreatment elonMuskTreatment ,ILogger logger) : base(logger)
        {
            _configs = configs;
            _connectionCollector = connectionCollector;
            _elonMuskTreatment = elonMuskTreatment;
        }

        public void Demo()
        {
            ExecutePart1();
            ExecutePart2();
            ExecutePart3();
        }

        private void ExecutePart1()
        {
            Logger.LogLogic("Start Part 1");

            foreach (var databaseConfiguration in _configs)
            {
                Logger.LogLogic(databaseConfiguration.ConnectionName);
            }

            Logger.LogLogic("End Part 1");
        }

        private void ExecutePart2()
        {
            Logger.LogLogic("Start Part 2");
            _connectionCollector.LogAll();
            Logger.LogLogic("End Part 2");
        }

        private void ExecutePart3()
        {
            Logger.LogLogic("Start Part 3");
            _elonMuskTreatment.Log();
            Logger.LogLogic("End Part 3");
        }
    }
}
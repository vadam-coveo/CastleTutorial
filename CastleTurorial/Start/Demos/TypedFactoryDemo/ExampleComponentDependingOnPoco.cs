using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.TypedFactoryDemo
{
    public class ExampleComponentDependingOnPoco : BaseComponent, IExampleServiceInterface, IDisposable
    {
        public SamplePoco Poco1 { get; }
        public SamplePoco Poco2 { get; }

        public ExampleComponentDependingOnPoco(SamplePoco samplePoco, ILogger logger) : base(logger)
        {
            Poco1 = samplePoco;
        }

        public ExampleComponentDependingOnPoco(SamplePoco poco1, SamplePoco poco2, ILogger logger) : base(logger)
        {
            Poco1 = poco1;
            Poco2 = poco2;
        }

        public void PerformAction()
        {
            Logger.LogLogic($"Called PerformAction() on {this}");
        }

        public override string ToString()
        {
            return $"{base.ToString()} with sample poco1 = '{Poco1?.Id}', poco2 = '{Poco2?.Id}'";
        }
    }
}

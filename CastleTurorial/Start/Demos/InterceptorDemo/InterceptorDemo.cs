using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.InterceptorDemo
{
    public class InterceptorDemo : BaseComponent, ICanBeDemoed
    {
        public IExceptionThrowingService Myservice { get; }

        public InterceptorDemo(IExceptionThrowingService exceptionThrowingComponent, ILogger logger) : base(logger)
        {
            Myservice = exceptionThrowingComponent;
        }

        public void Demo()
        {
            try
            {
                Myservice.DoYourThing("patate");
            }
            catch (Exception ex)
            {
                Logger.LogLogic($"Now we're done retrying!, exception was {ex.Message}");
            }

            try
            {
                Myservice.MyWonderfulRestApiCall("JB");
            }
            catch (Exception ex)
            {
                Logger.LogLogic($"Now we're done retrying!, exception was {ex.Message}");
            }
        }
    }
}

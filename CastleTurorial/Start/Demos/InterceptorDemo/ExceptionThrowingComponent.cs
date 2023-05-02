using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.InterceptorDemo
{
    public class ExceptionThrowingComponent : BaseComponent, IExceptionThrowingService
    {
        public ExceptionThrowingComponent(ILogger logger) : base(logger)
        {
        }
        public void DoYourThing(string withSomeArgument)
        {
            throw new Exception("I have thrown");
        }
    }
}

using Castle.DynamicProxy;
using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.InterceptorDemo
{
    public class RetryNTimesInterceptor : BaseComponent, IInterceptor
    {
        private readonly int _retries;

        public RetryNTimesInterceptor(int times, ILogger logger) : base(logger)
        {
            _retries = times;
        }

        public void Intercept(IInvocation invocation)
        {
            var attempt = 0;
            var done = false;

            while (!done)
            {
                try
                {
                    invocation.Proceed();
                    done = true;
                }
                catch (Exception ex)
                {
                    attempt++;
                    Logger.Error($"Exception raised when calling {invocation.TargetType.FullName}.{invocation.Method.Name}({GetArguments(invocation)}), tried {attempt} time(s)", ex);

                    if (attempt == _retries)
                    {
                        throw;
                    }
                }
            }
        }

        private string GetArguments(IInvocation invocation)
        {
            return string.Join(", ", invocation.Arguments.Select(x => $"<{x.GetType().FullName}> \"{x}\""));
        }
    }
}

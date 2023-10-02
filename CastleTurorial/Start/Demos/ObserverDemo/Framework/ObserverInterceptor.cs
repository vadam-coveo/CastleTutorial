using Castle.DynamicProxy;
using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.ObserverDemo.Framework
{
    public class ObserverInterceptor<TObservable> : BaseComponent, IInterceptor
        where TObservable : class
    {
        private IObserveeRegistrar<TObservable> Observees { get; }

        public ObserverInterceptor(IObserveeRegistrar<TObservable> observees, ILogger logger) : base(logger)
        {
            Observees = observees;
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();

            foreach (var observee in Observees.GetAll())
            {
                try
                {
                    observee.OnChange((TObservable)invocation.InvocationTarget);
                }
                catch (Exception ex)
                {
                    Logger.Error($"Uhandled error in observee {observee.GetType()}", ex);
                }
            }
        }
    }
}

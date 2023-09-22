using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace Start.Demos.ScopeDemo.CommonComponents
{
    public class ScopeProvider
    {
        private IWindsorContainer Container { get; }

        public ScopeProvider(IWindsorContainer container)
        {
            Container = container;
        }

        public IDisposable BeginScope()
        {
            return Container.BeginScope();
        }
    }
}

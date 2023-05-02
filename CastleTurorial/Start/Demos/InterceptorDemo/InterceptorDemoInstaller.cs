using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Start.Demos.InterceptorDemo
{
    public class InterceptorDemoInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ICanBeDemoed>().ImplementedBy<InterceptorDemo>(),

                Component.For<RetryNTimesInterceptor>()
                    .DependsOn(Dependency.OnValue<int>(3))
                    .Named("threetimesthecharm"),

                Component.For<IExceptionThrowingService>().ImplementedBy<ExceptionThrowingComponent>()
                    .Interceptors("threetimesthecharm")
            );
        }
    }
}

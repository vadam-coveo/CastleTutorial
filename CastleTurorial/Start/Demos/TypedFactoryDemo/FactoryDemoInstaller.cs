using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Start.StuffForHelping;

namespace Start.Demos.TypedFactoryDemo
{
    public class FactoryDemoInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.AddFacility(new TypedFactoryFacility());

            container.Register(Component.For<ICanBeDemoed>().ImplementedBy<TypedFactoryDemo>());

            container.Register(Component.For<IExampleTypedServiceFactory>().AsFactory());
            container.Register(Component.For<IExampleServiceInterface>().ImplementedBy<ExampleComponentDependingOnPoco>().LifestyleTransient());
        }
    }
}

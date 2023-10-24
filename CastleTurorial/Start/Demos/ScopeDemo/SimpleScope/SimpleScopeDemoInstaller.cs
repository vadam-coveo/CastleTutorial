using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Start.Demos.ScopeDemo.CommonComponents;

namespace Start.Demos.ScopeDemo.SimpleScope
{
    public class SimpleScopeDemoInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility(new TypedFactoryFacility());

            container.Register(

                Component.For<ICanBeDemoed>().ImplementedBy<SimpleScopeDemo>(),
                Component.For<ScopeProvider>().DependsOn(Dependency.OnValue<IWindsorContainer>(container)),

                Component.For<IAbstractFactory>().AsFactory(),

                Component.For<IStartingAddress>().ImplementedBy<StartingAddress>().LifestyleScoped(),
                Component.For<IComponentPerStartingAddress>().ImplementedBy<ComponentPerStartingAddress>().LifestyleScoped()
            );
        }
    }
}

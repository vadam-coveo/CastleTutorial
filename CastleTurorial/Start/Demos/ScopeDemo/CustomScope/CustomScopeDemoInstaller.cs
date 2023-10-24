using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Start.Demos.ScopeDemo.CommonComponents;
using Start.Demos.ScopeDemo.CustomScope.CustomScopeUtils;

namespace Start.Demos.ScopeDemo.CustomScope
{
    public class CustomScopeDemoInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility(new TypedFactoryFacility());

            container.Register(

                Component.For<ICanBeDemoed>().ImplementedBy<CustomScopeDemo>(),

                Component.For<IAbstractFactory>().AsFactory(),

                Component.For<IStartingAddress>().ImplementedBy<StartingAddress>()
                    .LifestyleScoped<CustomLogicalScopeAccessor<StartingAddress>>(),

                Component.For<IComponentPerStartingAddress>().ImplementedBy<ComponentPerStartingAddress>()
                    .LifestyleScoped<CustomLogicalScopeAccessor<StartingAddress>>(),

                Component.For<ScopeProvider>().DependsOn(Dependency.OnValue<IWindsorContainer>(container))
            );
        }
    }
}

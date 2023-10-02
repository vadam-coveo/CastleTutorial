using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Start.Demos.ObserverDemo.Components;
using Start.Demos.ObserverDemo.Framework;

namespace Start.Demos.ObserverDemo
{
    public class ObserverDemoInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(
                new CollectionResolver(container.Kernel, true));

            container.Register(
                Component.For<ICanBeDemoed>().ImplementedBy<ObserverDemo>(),

                Component.For<ObserverInterceptor<ObservableComponent>>().Named("Interceptor_For_ObservableComponent"),

                Component.For<IObserveeRegistrar<ObservableComponent>>()
                    .ImplementedBy<ObserveeRegistrar<ObservableComponent>>(),

                Component.For<IObservableComponent>().ImplementedBy<ObservableComponent>()
                    .Interceptors("Interceptor_For_ObservableComponent"),

                Component.For<IInterestedModule>().ImplementedBy<InterestedModule>()
                    .OnCreate(x => container.Resolve<IObserveeRegistrar<ObservableComponent>>().Register(x))
                    .OnDestroy(x => container.Resolve<IObserveeRegistrar<ObservableComponent>>().Unregister(x)),

                Component.For<ISomeOtherInterestedModule>().ImplementedBy<SomeOtherInterestedModule>()
                    .OnCreate(x => container.Resolve<IObserveeRegistrar<ObservableComponent>>().Register(x))
                    .OnDestroy(x => container.Resolve<IObserveeRegistrar<ObservableComponent>>().Unregister(x))

            );
        }
    }
}

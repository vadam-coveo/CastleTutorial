using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Start.Demos.ScopeDemo.CommonComponents;
using Start.Demos.ScopeDemo.CustomScope.CustomScopeComponents;
using Start.Demos.ScopeDemo.CustomScope.CustomScopeUtils;

namespace Start.Demos.ScopeDemo.CustomScope
{
    internal class CustomScopeDemo2Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {


            RegisterLessRelevantStuff(container);

            container.Register(

                Component.For<ICrawlingService>().ImplementedBy<CrawlingService>().LifestyleScoped<CustomLogicalScopeAccessor<CrawlingWorker>>(),
                Component.For<IMetadataExtractor>().ImplementedBy<MetadataExtractor>().LifestyleTransient(),

                Component.For<ICrawlingWorker>().ImplementedBy<CrawlingWorker>().LifestyleScoped<CustomLogicalScopeAccessor<CrawlingWorker>>(),
                Component.For<CrawlingWorkerState>().LifestyleScoped<CustomLogicalScopeAccessor<CrawlingWorker>>(),


                Component.For<IStartingAddress>().ImplementedBy<StartingAddress>().LifestyleScoped<CustomLogicalScopeAccessor<StartingAddress>>(),

                Component.For<ICrawlingJob>().ImplementedBy<CrawlingJob>()
            );
        }

        private void RegisterLessRelevantStuff(IWindsorContainer container)
        {
            container.AddFacility(new TypedFactoryFacility());
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));


            RegisterFactories(container);

            container.Register(
                Component.For<ICanBeDemoed>().ImplementedBy<CustomScopeDemo2>(),
                Component.For<ScopeProvider>().DependsOn(Dependency.OnValue<IWindsorContainer>(container))
            );
        }

        private void RegisterFactories(IWindsorContainer container)
        {
            container.Register(
                Component.For<IAbstractFactory>().AsFactory(),
                Component.For<IMetadataExtractorFactory>().AsFactory()
            );
        }
    }
}

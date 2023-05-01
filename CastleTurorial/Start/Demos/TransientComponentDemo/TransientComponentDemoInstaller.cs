using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Start.Demos.TransientComponentDemo
{
    public class TransientComponentDemoInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ICanBeDemoed>().ImplementedBy<TransientComponentDemo>());

            container.Register(Component.For<ITransientService>().ImplementedBy<MyTransientComponent>().LifestyleTransient());

            container.Register(Component.For<ISingletonService>().ImplementedBy<SingletonService>());
        }
    }
}

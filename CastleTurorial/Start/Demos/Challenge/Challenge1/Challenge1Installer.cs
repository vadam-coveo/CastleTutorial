using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Start.Demos.Challenge.Application;

namespace Start.Demos.Challenge.Challenge1
{
    public class Challenge1Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new ListResolver(container.Kernel, true));

            IDatabaseConfiguration visaConfiguration = new DatabaseConfiguration("Visa");
            
            container.Register(
                Component.For<ICanBeDemoed>().ImplementedBy<Challenge1Demo>(),
                Component.For<IDatabaseConfiguration>()
                    .ImplementedBy<DatabaseConfiguration>()
                    .DependsOn(Dependency.OnValue<string>("Mastercard"))
                    .Named("Mastercard"),
                Component.For<IDatabaseConfiguration>()
                    .Instance(visaConfiguration)
                    .Named("visa")
            );
        }
    }
}

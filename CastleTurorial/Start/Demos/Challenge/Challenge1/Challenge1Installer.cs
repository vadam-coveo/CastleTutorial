using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Diagnostics.Extensions;
using Start.Demos.Challenge.Application;
using Start.Demos.Challenge.Application.Paypal;
using Start.Demos.Challenge.Application.TD;

namespace Start.Demos.Challenge.Challenge1
{
    public class Challenge1Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new ListResolver(container.Kernel, true));
            container.Kernel.AddFacility(new StartableFacility());

            IDatabaseConfiguration visaConfiguration = new DatabaseConfiguration("Visa");

            container.Register(
                Component.For<ICanBeDemoed>().ImplementedBy<Challenge1Demo>(),
                Component.For<IPaypalFactory>().ImplementedBy<PaypalFactory>(),
                Component.For<IDatabaseConfiguration>()
                    .ImplementedBy<DatabaseConfiguration>()
                    .DependsOn(Dependency.OnValue<string>("Mastercard"))
                    .Named("DatabaseConfiguration.Mastercard"),
                Component.For<IDatabaseConfiguration>()
                    .Instance(visaConfiguration)
                    .Named("DatabaseConfiguration.Visa"),
                Component.For<IDatabaseConfiguration>()
                    .UsingFactoryMethod(() => container.Resolve<IPaypalFactory>().GetConfiguration())
                    .Named("DatabaseConfiguration.PayPal")
            );

            container.Register(
                Component.For<IDatabaseConnection>()
                    .ImplementedBy<DatabaseConnection>()
                    .DependsOn(Dependency.OnComponent(typeof(IDatabaseConfiguration),
                        "DatabaseConfiguration.Mastercard"))
                    //.DependsOn(ServiceOverride.ForKey("configuration").Eq("DatabaseConfiguration.Mastercard"))
                    .Named("DatabaseConnection.mastercard"),
                Component.For<IDatabaseConnection>()
                    .ImplementedBy<DatabaseConnection>()
                    .DependsOn(ServiceOverride.ForKey("configuration").Eq("DatabaseConfiguration.Visa"))
                    .Named("DatabaseConnection.Visa"),
                Component.For<IDatabaseConnection>()
                    .ImplementedBy<DatabaseConnection>()
                    .DependsOn(ServiceOverride.ForKey("configuration").Eq("DatabaseConfiguration.PayPal"))
                    .Named("DatabaseConnection.PayPal")
            );

            container.Register(
                Component.For<IDatabaseConnection>()
                    .ImplementedBy<TDBankConnection>()
                    .StartUsingMethod(nameof(TDBankConnection.CallBank))
                    .Start()
                    //.OnCreate(connection => )
            );

            container.Register(
                Component.For<IConnectionCollector>().ImplementedBy<ConnectionCollector>()
            );

            container.Register(
                Component.For<ISpecialElonMuskTreatment>()
                    .ImplementedBy<SpecialElonMuskTreatment>()
                    .DependsOn(Dependency.OnComponent(typeof(IDatabaseConnection), "DatabaseConnection.PayPal"))
            );
        }
    }
}
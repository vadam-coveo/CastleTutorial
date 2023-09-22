using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Start;
using Start.Demos.ScopeDemo.CustomScope;
using Start.Loggers;

var container = new WindsorContainer();

var installers = new[]
{
    new CustomScopeDemoInstaller()
};

const string space = "\n\n\n\n";

ConsoleLogger.WriteLine("-----------------Before installing-------------");
container.Install(installers);
container.Register(Component.For<ILogger>().ImplementedBy<ConsoleLogger>());
ConsoleLogger.WriteLine($"-----------------After installing-------------{space}");

var start = DateTime.Now;
ConsoleLogger.WriteLine("-----------------Before resolving root-------------");
var example = container.Resolve<ICanBeDemoed>();
ConsoleLogger.WriteLine($"-----------------After resolving root : {DateTime.Now - start}-------------{space}");


ConsoleLogger.WriteLine("-----------------Before calling demo-------------");
example.Demo();
ConsoleLogger.WriteLine($"-----------------After calling demo-------------{space}");


ConsoleLogger.WriteLine($"-----------------Before calling container dispose-------------");
container.Dispose();
ConsoleLogger.WriteLine($"-----------------After calling container dispose-------------{space}");

ConsoleLogger.WriteLine($"-----------------Before calling GC on container-------------");
GC.SuppressFinalize(container);
GC.Collect();
GC.WaitForPendingFinalizers();
ConsoleLogger.WriteLine($"-----------------After calling GC on container-------------{space}");

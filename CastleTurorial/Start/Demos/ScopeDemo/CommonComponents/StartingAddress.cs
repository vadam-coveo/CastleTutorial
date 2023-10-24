using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.ScopeDemo.CommonComponents
{
    public interface IStartingAddress : IDisposable
    {
        string Address { get; }
        HashSet<string> DiscoveredAddresses { get; }
    }

    public class StartingAddress : BaseComponent, IStartingAddress
    {
        public string Address { get; }

        public HashSet<string> DiscoveredAddresses { get; } = new ();

        public StartingAddress(string startingAddress, ILogger logger) : base(logger)
        {
            Address = startingAddress;
        }
    }
}

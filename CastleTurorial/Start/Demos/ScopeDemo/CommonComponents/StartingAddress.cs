using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.ScopeDemo.CommonComponents
{
    public interface IStartingAddress : IDisposable
    {
        string Address { get; }
    }

    public class StartingAddress : BaseComponent, IStartingAddress
    {
        public string Address { get; }

        public StartingAddress(string startingAddress, ILogger logger) : base(logger)
        {
            Address = startingAddress;
        }
    }
}

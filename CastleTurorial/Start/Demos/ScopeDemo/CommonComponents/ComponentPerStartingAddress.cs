using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.ScopeDemo.CommonComponents
{
    public interface IComponentPerStartingAddress
    {
        Guid ComponentId { get; }
    }

    public class ComponentPerStartingAddress : BaseComponent, IComponentPerStartingAddress, IDisposable
    {
        public IStartingAddress Startingaddress { get; }
        public Guid ComponentId { get; } = Guid.NewGuid();

        public ComponentPerStartingAddress(IStartingAddress startingaddress, ILogger logger) : base(logger)
        {
            Startingaddress = startingaddress;
        }

        public override string ToString()
        {
            return $"ComponentPerStartingAddress GUID = {ComponentId}, starting address = {Startingaddress?.Address}";
        }
    }
}

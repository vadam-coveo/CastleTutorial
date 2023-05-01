using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.TransientComponentDemo
{
    public class MyTransientComponent : BaseComponent, ITransientService
    {
        public Guid GetGuid => Guid;
        public MyTransientComponent(ILogger logger) : base(logger)
        {
        }
    }
}

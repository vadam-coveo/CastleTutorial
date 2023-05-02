using Castle.Core;
using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.Challenge.Application.TD;

public class TDBankConnection : BaseComponent, IDatabaseConnection
{
    public TDBankConnection(ILogger logger) : base(logger)
    {
    }

    public void CallBank()
    {
        Logger.LogLogic("Calling bank");
    }

    public string GetInstanceName()
    {
        return "TD";
    }
}
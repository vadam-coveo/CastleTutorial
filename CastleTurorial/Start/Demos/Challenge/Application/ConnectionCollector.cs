using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.Challenge.Application;

public class ConnectionCollector : BaseComponent, IConnectionCollector, IDisposable
{
    private readonly IList<IDatabaseConnection> _connections;

    public ConnectionCollector(IList<IDatabaseConnection> connections, ILogger logger) : base(logger)
    {
        _connections = connections;
    }
    
    public void LogAll()
    {
        foreach (var databaseConnection in _connections)
        {
            Logger.LogLogic($"GetInstanceName: {databaseConnection.GetInstanceName()}");
        }
    }
}
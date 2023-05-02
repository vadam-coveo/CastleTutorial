using Start.Loggers;
using Start.StuffForHelping;

namespace Start.Demos.Challenge.Application.Paypal;

public class SpecialElonMuskTreatment : BaseComponent, ISpecialElonMuskTreatment
{
    private readonly IDatabaseConnection _connection;

    public SpecialElonMuskTreatment(IDatabaseConnection connection, ILogger logger) : base(logger)
    {
        _connection = connection;
    }
    
    public void Log()
    {
        Logger.LogLogic(_connection.GetInstanceName());
    }
}
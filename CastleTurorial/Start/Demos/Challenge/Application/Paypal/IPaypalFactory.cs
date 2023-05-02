namespace Start.Demos.Challenge.Application.Paypal;

public interface IPaypalFactory
{
    IDatabaseConfiguration GetConfiguration();

    string ResolveConnectionName { get; }
}
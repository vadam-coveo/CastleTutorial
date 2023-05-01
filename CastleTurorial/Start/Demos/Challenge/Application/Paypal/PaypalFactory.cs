namespace Start.Demos.Challenge.Application.Paypal
{
    public class PaypalFactory : IPaypalFactory
    {
        public string ResolveConnectionName => $"Paypal - {DateTime.Now}";
    }
}

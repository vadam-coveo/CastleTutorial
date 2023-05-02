namespace Start.Demos.Challenge.Application.Paypal
{
    public class PaypalFactory : IPaypalFactory
    {
        public IDatabaseConfiguration GetConfiguration()
        {
            return new DatabaseConfiguration("Paypal");
        }

        public string ResolveConnectionName => $"Paypal - {DateTime.Now}";
    }
}

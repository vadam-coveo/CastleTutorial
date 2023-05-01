namespace Start.Demos.Challenge.Application
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public string ConnectionName { get; }

        public DatabaseConfiguration(string connectionName)
        {
            ConnectionName = connectionName;
        }

    }
}

namespace Timmy.Aliments
{
    public interface IAliment
    {
        public string Name { get; }

        public bool ShouldBeStoredInFridge { get; }
    }
}

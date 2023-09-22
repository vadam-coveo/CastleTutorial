namespace Start.Demos.ScopeDemo.CommonComponents
{
    public interface IComponentFactory
    {
        public IStartingAddress CreateStartingAddress(string startingAddress);

        public IComponentPerStartingAddress ResolveComponentForStartingAddress();
    }
}

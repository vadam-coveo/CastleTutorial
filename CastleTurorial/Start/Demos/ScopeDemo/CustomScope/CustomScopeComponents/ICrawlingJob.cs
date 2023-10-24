namespace Start.Demos.ScopeDemo.CustomScope.CustomScopeComponents;

public interface ICrawlingJob
{
    void AddAddress(string address);
    IEnumerable<string> GetAllDiscoveredAddresses();
}
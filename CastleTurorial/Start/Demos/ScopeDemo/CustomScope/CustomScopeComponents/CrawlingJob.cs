using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Demos.ScopeDemo.CustomScope.CustomScopeComponents
{
    public class CrawlingJob : ICrawlingJob
    {
        public ConcurrentStack<string> AllAddresses = new();


        public void AddAddress(string address)
        {
            AllAddresses.Push(address);
        }

        public IEnumerable<string> GetAllDiscoveredAddresses()
        {
            return AllAddresses.ToArray();
        }
    }
}

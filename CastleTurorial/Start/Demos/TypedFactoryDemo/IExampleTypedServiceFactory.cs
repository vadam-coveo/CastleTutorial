using Start.StuffForHelping;

namespace Start.Demos.TypedFactoryDemo
{
    public interface IExampleTypedServiceFactory : IDisposable
    {
        public IExampleServiceInterface Resolve(SamplePoco samplePoco);
        public IExampleServiceInterface Resolve(SamplePoco poco1, SamplePoco poco2);
        public void Release(IExampleServiceInterface instance);
    }
}

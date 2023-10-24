using Castle.MicroKernel.Context;
using Castle.MicroKernel.Lifestyle.Scoped;

namespace Start.Demos.ScopeDemo.CustomScope.CustomScopeUtils
{
    public class CustomLogicalScopeAccessor<T> : IScopeAccessor where T : class
    {
        [Obsolete]
        public void Dispose()
        {
            CustomLogicalScope<T>.ObtainCurrentScope()?.Dispose();
        }

        public ILifetimeScope GetScope(CreationContext context)
        {
            var scope = CustomLogicalScope<T>.ObtainCurrentScope();  
            if (scope == null)
            {
                throw new InvalidOperationException($"Scope was not available. Did you forget to instantiate a new CustomLogicalScopeAccessor<${typeof(T)}> upstream for component {context.Handler.ComponentModel.ComponentName}?");
            }
            return scope;
        }
    } 
}

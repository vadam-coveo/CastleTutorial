using Castle.Core;
using Castle.Core.Internal;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle.Scoped;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Globalization;
using System.Security;

namespace Start.Demos.ScopeDemo.CustomScope.CustomScopeUtils;

/// <summary>
///   Provides explicit lifetime scoping within logical path of execution.
/// </summary>
/// <remarks>
///   The scope is passed on to child threads, including ThreadPool threads. The capability is limited to single <see
///    cref="AppDomain" /> and should be used cautiously as call to <see cref="Dispose" /> may occur while the child thread is still executing, what in turn may lead to subtle threading bugs.
/// </remarks>
public class CustomLogicalScope<T> : ILifetimeScope where T : class
{
    private static readonly ConcurrentDictionary<Guid, CustomLogicalScope<T>> appDomainLocalInstanceCache = new();

    private static readonly string keyInCallContext = "customLogicalScope-" + typeof(T).FullName + AppDomain.CurrentDomain.Id.ToString(CultureInfo.InvariantCulture);
    private readonly Guid contextId;
    [Obsolete]
    private readonly Lock @lock = Lock.Create();
    private readonly CustomLogicalScope<T> parentScope;
    private ScopeCache? cache = new();


    public CustomLogicalScope()
    {
        var parent = ObtainCurrentScope();
        if (parent != null)
        {
            parentScope = parent;
        }
        contextId = Guid.NewGuid();

        var added = appDomainLocalInstanceCache.TryAdd(contextId, this);
        Debug.Assert(added);

        SetCurrentScope(this);
    }

    [SecuritySafeCritical]
    [Obsolete]
    public void Dispose()
    {
        using (var token = @lock.ForReadingUpgradeable())
        {
            if (cache == null)
            {
                return;
            }
            token.Upgrade();
            cache.Dispose();
            cache = null;

            if (parentScope != null)
            {
                SetCurrentScope(parentScope);
            }
            else
            {
                CallContext.Erase(keyInCallContext);
            }
        }

        appDomainLocalInstanceCache.TryRemove(contextId, out _);
    }

    [Obsolete]
    public Burden GetCachedInstance(ComponentModel model, ScopedInstanceActivationCallback createInstance)
    {
        using (var token = @lock.ForReadingUpgradeable())
        {
            var burden = cache[model];
            if (burden == null)
            {
                token.Upgrade();

                burden = createInstance(delegate { });
                cache[model] = burden;
            }
            return burden;
        }
    }


    [SecuritySafeCritical]
    private void SetCurrentScope(CustomLogicalScope<T> lifetimeScope)
    {
        CallContext.Set(keyInCallContext, lifetimeScope.contextId);
    }


    [SecuritySafeCritical]
    public static CustomLogicalScope<T>? ObtainCurrentScope()
    {
        var scopeKey = CallContext.Get(keyInCallContext);
        if (scopeKey == null)
        {
            return null;
        }

        appDomainLocalInstanceCache.TryGetValue((Guid)scopeKey, out var scope);
        return scope;
    }
}
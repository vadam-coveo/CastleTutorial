using System.Collections.Concurrent;

namespace Start.Demos.ScopeDemo.CustomScope.CustomScopeUtils
{
    /// <summary>
    /// Provides a way to set contextual data that flows with the call and 
    /// async context of a test or invocation. Equivalent of the CallContext class
    /// that's part of  System.Runtime.Remoting.Messaging which hasn't been ported to .net core
    /// see : https://learn.microsoft.com/en-us/dotnet/api/system.runtime.remoting.messaging.callcontext?view=netframework-4.8.1
    /// inspired from : https://www.cazzulino.com/callcontext-netstandard-netcore.html
    /// </summary>
    public static class CallContext<T> where T : class
    {
        static ConcurrentDictionary<string, AsyncLocal<T>> state = new();

        /// <summary>
        /// Stores a given object and associates it with the specified key.
        /// </summary>
        /// <param key="key">The key with which to associate the new item in the call context.</param>
        /// <param key="data">The object to store in the call context.</param>
        public static void Set(string key, T data) => state.GetOrAdd(key, _ => new AsyncLocal<T>()).Value = data;

        /// <summary>
        /// Retrieves an object with the specified key from the <see cref="CallContext<>"/>.
        /// </summary>
        /// <param key="key">The key of the item in the call context.</param>
        /// <returns>The object in the call context associated with the specified key, or <see langword="null"/> if not found.</returns>
        public static T? Get(string key) => state.TryGetValue(key, out AsyncLocal<T>? data) ? data.Value : null;

        public static void Erase(string key)
        {
            state.TryRemove(key, out _);
        }
    }

    /// <summary>
    /// Provides a way to set contextual data that flows with the call and 
    /// async context of a test or invocation. Equivalent of the CallContext class
    /// that's part of  System.Runtime.Remoting.Messaging which hasn't been ported to .net core
    /// see : https://learn.microsoft.com/en-us/dotnet/api/system.runtime.remoting.messaging.callcontext?view=netframework-4.8.1
    /// inspired from : https://www.cazzulino.com/callcontext-netstandard-netcore.html
    /// </summary>
    public static class CallContext
    {
        static ConcurrentDictionary<string, AsyncLocal<object>> state = new();

        /// <summary>
        /// Stores a given object and associates it with the specified key.
        /// </summary>
        /// <param key="key">The key with which to associate the new item in the call context.</param>
        /// <param key="data">The object to store in the call context.</param>
        public static void Set(string key, object data) => state.GetOrAdd(key, _ => new AsyncLocal<object>()).Value = data;

        /// <summary>
        /// Retrieves an object with the specified key from the <see cref="CallContext"/>.
        /// </summary>
        /// <param key="key">The key of the item in the call context.</param>
        /// <returns>The object in the call context associated with the specified key, or <see langword="null"/> if not found.</returns>
        public static object? Get(string key) => state.TryGetValue(key, out AsyncLocal<object>? data) ? data.Value : null;

        public static void Erase(string key)
        {
            state.TryRemove(key, out _);
        }
    }
}

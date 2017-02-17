using System;
using System.Runtime.Caching;

namespace CacheCSharp
{
    class MemoryProvider : CacheProviderBase<System.Runtime.Caching.MemoryCache>
    {
        protected override MemoryCache InitCache()
        {
            return MemoryCache.Default;
        }

        public override T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public override void Set<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public override void SetSliding<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public override void Set<T>(string key, T value, int duration)
        {
            throw new NotImplementedException();
        }

        public override void SetSliding<T>(string key, T value, int duration)
        {
            throw new NotImplementedException();
        }

        public override void Set<T>(string key, T value, DateTimeOffset expiration)
        {
            throw new NotImplementedException();
        }

        public override bool Exists(string key)
        {
            return Cache[key] != null;
        }

        public override void Remove(string key)
        {
            Cache.Remove(KeyPrefix + key);
        }
    }
}

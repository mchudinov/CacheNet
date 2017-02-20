using System;
using System.Runtime.Caching;

namespace CacheCSharp
{
    public class MemoryProvider : CacheProviderBase<System.Runtime.Caching.MemoryCache>
    {
        protected override MemoryCache InitCache()
        {
            return MemoryCache.Default;
        }

        public override T Get<T>(string key)
        {
            try
            {
                if (Cache[KeyPrefix + key] == null)
                {
                    return default(T);
                }

                return (T)Cache[KeyPrefix + key];
            }
            catch
            {
                return default(T);
            }
        }

        public override void Set<T>(string key, T value)
        {
            var policy = new CacheItemPolicy();
            Cache.Set(key, value, policy);
        }

        public override void SetSliding<T>(string key, T value)
        {
            SetSliding<T>(KeyPrefix + key, value, CacheDuration);
        }

        public override void Set<T>(string key, T value, int duration)
        {
            var policy = new CacheItemPolicy {AbsoluteExpiration = DateTime.Now.AddMinutes(duration)};
            Cache.Set(key, value, policy);
        }

        public override void SetSliding<T>(string key, T value, int duration)
        {
            var policy = new CacheItemPolicy { SlidingExpiration = new TimeSpan(0, duration, 0) };
            Cache.Set(key, value, policy);
        }

        public override void Set<T>(string key, T value, DateTimeOffset expiration)
        {
            var policy = new CacheItemPolicy { AbsoluteExpiration = expiration.DateTime };
            Cache.Set(key, value, policy);
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

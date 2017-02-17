using System;
using System.Web;

namespace CacheCSharp
{
    public class HttpCache : CacheProvider<System.Web.Caching.Cache>
    {
        protected override System.Web.Caching.Cache InitCache()
        {
            return HttpRuntime.Cache;
        }

        public override T Get<T>(string key)
        {
            try
            {
                if (Cache[KeyPrefix+key] == null)
                {
                    return default(T);
                }

                return (T)Cache[KeyPrefix+key];
            }
            catch
            {
                return default(T);
            }
        }

        public override void Set<T>(string key, T value)
        {
            Set<T>(KeyPrefix+key, value, CacheDuration);
        }

        public override void SetSliding<T>(string key, T value)
        {
            SetSliding<T>(KeyPrefix+key, value, CacheDuration);
        }

        public override void SetSliding<T>(string key, T value, int duration)
        {
            Cache.Insert(
                KeyPrefix+key,
                value,
                null,
                DateTime.Now.AddMinutes(duration),
                System.Web.Caching.Cache.NoSlidingExpiration);
        }

        public override void Set<T>(string key, T value, DateTimeOffset expiration)
        {
            Cache.Insert(
                KeyPrefix + key,
                value,
                null,
                expiration.DateTime, 
                System.Web.Caching.Cache.NoSlidingExpiration);
        }

        public override bool Exists(string key)
        {
            return Cache[key] != null;
        }

        public override void Set<T>(string key, T value, int duration)
        {
            Cache.Insert(
                KeyPrefix+key,
                value,
                null,
                System.Web.Caching.Cache.NoAbsoluteExpiration,
                new TimeSpan(0, duration, 0));
        }

        public override void Remove(string key)
        {
            Cache.Remove(KeyPrefix+key);
        }
    }
}

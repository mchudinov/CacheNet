using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test memory cache");
            CacheCSharp.ICache cacheMemory = new CacheCSharp.MemoryProvider();
            cacheMemory.Set("key1", new Widget {Name = "memory cache", Number = 1});
            Console.WriteLine(cacheMemory.Get<Widget>("key1").Number + "-" + cacheMemory.Get<Widget>("key1").Name);            

            Console.WriteLine("Test System.Web cache");
            CacheVB.ICache cacheSystemWebVB = new CacheVB.SystemWebProvider();
            cacheSystemWebVB.SetValue("key2", new Widget { Name = "System.Web cache VB", Number = 2 });
            Console.WriteLine(cacheSystemWebVB.GetValue<Widget>("key2").Number + "-" + cacheSystemWebVB.GetValue<Widget>("key2").Name);


            CacheCSharp.ICache cacheSystemWebCS = new CacheCSharp.SystemWebProvider();
            cacheSystemWebCS.Set("key3", new Widget { Name = "System.Web cache C#", Number = 3 });
            Console.WriteLine(cacheSystemWebCS.Get<Widget>("key3").Number + "-" + cacheSystemWebCS.Get<Widget>("key3").Name);

            Console.WriteLine("Test CacheManager cache");
            CacheVB.ICache cacheCacheManagerVB = new CacheVB.CacheManagerProvider();
            cacheCacheManagerVB.SetValue("key4", new Widget { Name = "CacheManager cache VB", Number = 4 });
            Console.WriteLine(cacheCacheManagerVB.GetValue<Widget>("key4").Number + "-" + cacheCacheManagerVB.GetValue<Widget>("key4").Name);


            CacheCSharp.ICache cacheCacheManagerCS = new CacheCSharp.SystemWebProvider();
            cacheCacheManagerCS.Set("key5", new Widget { Name = "CacheManager cache C#", Number = 3 });
            Console.WriteLine(cacheCacheManagerCS.Get<Widget>("key5").Number + "-" + cacheCacheManagerCS.Get<Widget>("key5").Name);

            Console.ReadLine();
        }

        internal class Widget
        {
            public int Number { get; set; }
            public string Name { get; set; }
        }
    }
}

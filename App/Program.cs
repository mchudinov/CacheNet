﻿using System;
using System.Threading.Tasks;
using CacheCSharp;

namespace App
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(">> Test memory cache");
            CacheVB.ICache cacheManagerVB = new CacheVB.MemoryProvider();
            cacheManagerVB.Set("key1", new Widget { Name = "memory cache VB", Number = 1 });
            var temp = cacheManagerVB.Get<Widget>("key1");
            Console.WriteLine(temp.Number + "-" + temp.Name);            

            CacheCSharp.ICache cacheCacheManagerCScacheMemoryCS = new CacheCSharp.MemoryProvider();
            CacheCSharp.ICache cacheMemoryCS = new CacheCSharp.MemoryProvider();
            cacheMemoryCS.Set("key2", new Widget {Name = "memory cache C#", Number = 2});
            temp = cacheMemoryCS.Get<Widget>("key2");
            Console.WriteLine(temp.Number + "-" + temp.Name);


            Console.WriteLine(">> Test System.Web cache");
            CacheVB.ICache cacheSystemWebVB = new CacheVB.SystemWebProvider();
            cacheSystemWebVB.Set("key3", new Widget { Name = "System.Web cache VB", Number = 3 });
            temp = cacheSystemWebVB.Get<Widget>("key3");
            Console.WriteLine(temp.Number + "-" + temp.Name);


            CacheCSharp.ICache cacheSystemWebCS = new CacheCSharp.SystemWebProvider();
            cacheSystemWebCS.Set("key4", new Widget { Name = "System.Web cache C#", Number = 4 });
            temp = cacheSystemWebCS.Get<Widget>("key4");
            Console.WriteLine(temp.Number + "-" + temp.Name);

            Console.WriteLine(">> Test CacheManager cache");
            CacheVB.ICache cacheCacheManagerVB = new CacheVB.CacheManagerProvider();
            cacheCacheManagerVB.Set("key5", new Widget { Name = "CacheManager cache VB", Number = 5 });
            temp = cacheCacheManagerVB.Get<Widget>("key5");
            Console.WriteLine(temp.Number + "-" + temp.Name);


            CacheCSharp.ICache cacheCacheManagerCS = new CacheCSharp.SystemWebProvider();
            cacheCacheManagerCS.Set("key6", new Widget { Name = "CacheManager cache C#", Number = 6 });
            temp = cacheCacheManagerCS.Get<Widget>("key6");
            Console.WriteLine(temp.Number + "-" + temp.Name);

            Console.WriteLine(">> Extension methods");
            Console.WriteLine(cacheCacheManagerCS.UseCached<string>("key7", temp.GetValue, 10));
            

            var asyncResult = cacheCacheManagerCS.UseCachedAsync<string>("key8", temp.GetValueAsync, 10);
            Task.WaitAll(asyncResult); // block while the task completes
            Console.WriteLine(asyncResult.Result);

            Console.WriteLine("Done. Press ENTER.");
            Console.ReadLine();
        }

        internal class Widget
        {
            public int Number { get; set; }
            public string Name { get; set; }

            public string GetValue()
            {
                return "sync value return";
            }

            public async Task<string> GetValueAsync()
            {
                await Task.Delay(1000);
                return "async method return";
            }
        }
    }
}

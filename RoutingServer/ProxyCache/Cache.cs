using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ProxyCache
{

    class Cache<T> where T : class
    {
        ObjectCache cache = MemoryCache.Default;
        DateTimeOffset dt_default = ObjectCache.InfiniteAbsoluteExpiration;
        public T Get(string CacheItem)
        {
            T obj = (T)cache.Get(CacheItem);
            if (obj != null)
                return obj;
            T Obj2 = default(T);
            if (Obj2 != null)
            {
                this.cache.Add(CacheItem, Obj2, dt_default);
            }
            return Obj2;
        }
        public T Get(string CacheItem, double dt_seconds)
        {
            T obj = (T)cache.Get(CacheItem);
            if (obj != null)
                return obj;
            T Obj2 = default(T);
            if (Obj2 != null)
            {
                DateTimeOffset seconds = new DateTimeOffset();
                seconds.AddSeconds(dt_seconds);
                this.cache.Add(CacheItem, Obj2, seconds);
            }
            return Obj2;
        }
        public T Get(string CacheItem, DateTimeOffset dt)
        {
            T obj = (T)cache.Get(CacheItem);
            if (obj != null)
                return obj;
            T Obj2 = default(T);
            if (Obj2 != null)
            {
                this.cache.Add(CacheItem, Obj2, dt);
            }
            return Obj2;
        }

        public void Set(string CacheItem, T obj,double dt)
        {
            this.cache.Add(CacheItem, obj, new DateTimeOffset().AddSeconds(dt));
        }
        public ObjectCache getCache()
        {
            return this.cache;
        }
    }
}

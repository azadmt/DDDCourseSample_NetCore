using Framework.Core.Cache;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Framework.Cache
{
    public class MicrosoftExtensionsCacheManager : ICacheManager
    {
        readonly IMemoryCache cache;
        public MicrosoftExtensionsCacheManager(IMemoryCache cache)
        {
            this.cache = cache;
        }
        public void Set(ICacheKey cacheKey, object value)
        {
            cache.Set(cacheKey.GetKey(), value);
        }
        public T Get<T>(ICacheKey cacheKey)
        {
           return cache.Get<T>(cacheKey.GetKey());

        }
    }
}

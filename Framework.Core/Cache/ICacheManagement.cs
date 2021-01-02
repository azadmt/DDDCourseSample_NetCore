using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Cache
{
    public interface ICacheManager
    {
        void Set(ICacheKey cacheKey, object value);
        T Get<T>(ICacheKey cacheKey);
    }



    public interface ICacheKey
    {
        string GetKey();
    }
}

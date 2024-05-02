using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using RedisCacheExtension.Interfaces;

namespace RedisCacheExtension.Services
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache? _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public void SetData<T>(string key, T element, TimeSpan cacheDuration)
        {
            var json = JsonSerializer.Serialize(element);

            _cache!.SetString(key, json, new() { AbsoluteExpirationRelativeToNow = cacheDuration });
        }

        public T GetData<T>(string key)
        {
            var data = _cache!.GetString(key) ?? string.Empty;

            if (data == string.Empty)
            {
                return default(T)!;
            }

            return JsonSerializer.Deserialize<T>(data)!;
        }

    }
}

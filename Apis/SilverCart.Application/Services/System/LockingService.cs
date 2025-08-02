using Infrastructures.Interfaces.System;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructures.Services.System
{
    public class LockingService(IDistributedCache distributedCache) : ILockingService
    {
        private readonly IDistributedCache _distributedCache = distributedCache;
        public async Task<T> GetCacheAsync<T>(string key)
        {
            var cachedData = await _distributedCache.GetStringAsync(key);
            if (string.IsNullOrEmpty(cachedData))
                return default!;

            return JsonSerializer.Deserialize<T>(cachedData)!;
        }

        public async Task<bool> IsCacheExistsAsync(string key)
        {
            var cachedData = await _distributedCache.GetAsync(key);
            return cachedData != null;
        }

        public async Task RemoveCacheAsync(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }

        public async Task SetCacheAsync<T>(string key, T value, TimeSpan expirationTime)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expirationTime
            };
            var serializedData = JsonSerializer.Serialize(value);
            await _distributedCache.SetStringAsync(key, serializedData, options);
        }
    }
}

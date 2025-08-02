using System.Text.Json;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructures.Services.System
{
    public class RedisService : IRedisService
    {
        private readonly IDatabase _db;

        public RedisService(IConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            await _db.StringSetAsync(key, JsonSerializer.Serialize(value), expiry);
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var result = await _db.StringGetAsync(key);
            return result.HasValue ? JsonSerializer.Deserialize<T>(result.ToString()) : default;
        }

        public async Task<bool> DeleteAsync(string key)
        {
            return await _db.KeyDeleteAsync(key);
        }
    }
}
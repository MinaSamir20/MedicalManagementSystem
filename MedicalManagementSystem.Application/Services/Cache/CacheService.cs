using StackExchange.Redis;
using System.Text.Json;

namespace MedicalManagementSystem.Application.Services.Cache
{
    public class CacheService(IConnectionMultiplexer redis) : ICacheService
    {
        private readonly IDatabase _database = redis.GetDatabase();

        public async Task<string> GetCacheResponseAsync(string key)
        {
            var cacheResponse = await _database.StringGetAsync(key);

            if (cacheResponse.IsNullOrEmpty)
                return null!;

            return cacheResponse.ToString();
        }

        public async Task SetCacheResponseAsync(string key, object response, TimeSpan timeToLive)
        {
            if (response is null)
                return;

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var serializedResponse = JsonSerializer.Serialize(response, options);

            await _database.StringSetAsync(key, serializedResponse, timeToLive);
        }
    }
}

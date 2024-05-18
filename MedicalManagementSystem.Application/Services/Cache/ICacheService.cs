namespace MedicalManagementSystem.Application.Services.Cache
{
    public interface ICacheService
    {
        Task SetCacheResponseAsync(string key, object response, TimeSpan timeToLive);
        Task<string> GetCacheResponseAsync(string key);
    }
}

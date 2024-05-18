using MedicalManagementSystem.Application.Services.Cache;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace MedicalManagementSystem.Api.Helper
{
    [AttributeUsage(AttributeTargets.All)]
    public class CacheAttribute(int timeToLivInSecounds) : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToLivInSecounds = timeToLivInSecounds;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var _cacheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();

            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);

            var cachedResponse = await _cacheService.GetCacheResponseAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedResponse))
            {
                var contentResult = new ContentResult
                {
                    Content = cachedResponse,
                    ContentType = "application/json",
                    StatusCode = 200,
                };

                context.Result = contentResult;
                return;
            }

            var executedContext = await next();

            if (executedContext.Result is OkObjectResult response)
                await _cacheService.SetCacheResponseAsync(cacheKey, response.Value!, TimeSpan.FromSeconds(_timeToLivInSecounds));
        }

        private static string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            StringBuilder cacheKey = new();
            cacheKey.Append($"{request.Path}");
            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
                cacheKey.Append($"|{key}-{value}");
            return cacheKey.ToString();
        }
    }
}

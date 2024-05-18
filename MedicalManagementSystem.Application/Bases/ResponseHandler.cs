using MedicalManagementSystem.Core.SharedResources;
using Microsoft.Extensions.Localization;

namespace MedicalManagementSystem.Application.Bases
{
    public class ResponseHandler(IStringLocalizer<SharedResources> localizer)
    {
        private readonly IStringLocalizer<SharedResources> _localizer = localizer;

        public Response<T> Deleted<T>(string? Message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = Message ?? _localizer![SharedResourcesKeys.Deleted],
            };
        }

        public Response<T> Success<T>(T entity, object? Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = _localizer![SharedResourcesKeys.Success],
                Meta = Meta
            };
        }

        public Response<T> Unauthorized<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = _localizer![SharedResourcesKeys.UnAuthorized]
            };
        }

        public Response<T> BadRequest<T>(string? Message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message ?? _localizer![SharedResourcesKeys.BadRequest]
            };
        }

        public Response<T> UnprocessableEntity<T>(string Message)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = Message ?? _localizer![SharedResourcesKeys.UnprocessableEntity]
            };
        }

        public Response<T> NotFound<T>(string? Message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = Message ?? _localizer![SharedResourcesKeys.NotFound]
            };
        }
        public Response<T> Created<T>(T entity, object? Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = _localizer![SharedResourcesKeys.Added],
                Meta = Meta
            };
        }
    }
}

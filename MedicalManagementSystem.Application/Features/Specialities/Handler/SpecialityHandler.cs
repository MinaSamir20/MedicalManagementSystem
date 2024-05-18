using AutoMapper;
using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Application.Features.Specialities.Models;
using MedicalManagementSystem.Application.Features.Specialities.Responces;
using MedicalManagementSystem.Application.Services.Specialities;
using MedicalManagementSystem.Application.Wrappers;
using MedicalManagementSystem.Core.SharedResources;
using MedicalManagementSystem.Domain.Entities;
using Microsoft.Extensions.Localization;
using System.Linq.Expressions;

namespace MedicalManagementSystem.Application.Features.Specialities.Handler
{
    public class SpecialityHandler(IMapper mapper, ISpecialitiesService service, IStringLocalizer<SharedResources> localizer)
        : ResponseHandler(localizer),
        IRequestHandler<GetSpecialityList, Response<IEnumerable<GetSpecialityResponse>>>,
        IRequestHandler<GetSpecialityDetails, Response<GetSpecialityResponse>>,
        IRequestHandler<GetSpecialityPaginatedList, PaginatedResult<GetSpecialityPaginatedResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ISpecialitiesService _service = service;
        private readonly IStringLocalizer<SharedResources> _localizer = localizer;

        public async Task<Response<IEnumerable<GetSpecialityResponse>>> Handle(GetSpecialityList request, CancellationToken cancellationToken)
        {
            var specialities = await _service.GetAll();
            return Success(_mapper.Map<IEnumerable<GetSpecialityResponse>>(specialities));
        }

        public async Task<Response<GetSpecialityResponse>> Handle(GetSpecialityDetails request, CancellationToken cancellationToken)
        {
            var speciality = await _service.Get(a => a.Id == request.Id);

            return speciality == null ? NotFound<GetSpecialityResponse>(_localizer[SharedResourcesKeys.NotFound]) : Success(_mapper.Map<GetSpecialityResponse>(speciality));
        }

        public async Task<PaginatedResult<GetSpecialityPaginatedResponse>> Handle(GetSpecialityPaginatedList request, CancellationToken cancellationToken)
        {
            Expression<Func<Speciality, GetSpecialityPaginatedResponse>> Expression = e => new GetSpecialityPaginatedResponse(e.Id, e.GetLocalized(e.SNameEn, e.SNameAr));
            var filter = _service.Filter(request.SearchBy, request.Search, request.OrderBy, request.OrderType!);
            var paginated = await filter.Select(Expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            paginated.Meta = new { paginated.Data.Count };
            return paginated!;
        }
    }
}

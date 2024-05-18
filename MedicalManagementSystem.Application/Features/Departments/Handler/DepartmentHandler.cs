using AutoMapper;
using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Application.Features.Departments.Models;
using MedicalManagementSystem.Application.Features.Departments.Responces;
using MedicalManagementSystem.Application.Services.Specialities;
using MedicalManagementSystem.Application.Wrappers;
using MedicalManagementSystem.Core.SharedResources;
using MedicalManagementSystem.Domain.Entities;
using Microsoft.Extensions.Localization;
using System.Linq.Expressions;

namespace MedicalManagementSystem.Application.Features.Departments.Handler
{
    public class DepartmentHandler(IMapper mapper, ISpecialitiesService service, IStringLocalizer<SharedResources> localizer)
        : ResponseHandler(localizer),
        IRequestHandler<GetDepartmentList, Response<IEnumerable<GetDepartmentResponse>>>,
        IRequestHandler<GetDepartmentDetails, Response<GetDepartmentResponse>>,
        IRequestHandler<GetDepartmentPaginatedList, PaginatedResult<GetDepartmentPaginatedResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ISpecialitiesService _service = service;
        private readonly IStringLocalizer<SharedResources> _localizer = localizer;

        public async Task<Response<IEnumerable<GetDepartmentResponse>>> Handle(GetDepartmentList request, CancellationToken cancellationToken)
        {
            var specialities = await _service.GetAll();
            return Success(_mapper.Map<IEnumerable<GetDepartmentResponse>>(specialities));
        }

        public async Task<Response<GetDepartmentResponse>> Handle(GetDepartmentDetails request, CancellationToken cancellationToken)
        {
            var speciality = await _service.Get(a => a.Id == request.Id);

            return speciality == null ? NotFound<GetDepartmentResponse>(_localizer[SharedResourcesKeys.NotFound]) : Success(_mapper.Map<GetDepartmentResponse>(speciality));
        }

        public async Task<PaginatedResult<GetDepartmentPaginatedResponse>> Handle(GetDepartmentPaginatedList request, CancellationToken cancellationToken)
        {
            Expression<Func<Speciality, GetDepartmentPaginatedResponse>> Expression = e => new GetDepartmentPaginatedResponse(e.Id, e.GetLocalized(e.SNameEn, e.SNameAr));
            var filter = _service.Filter(request.SearchBy, request.Search, request.OrderBy, request.OrderType!);
            var paginated = await filter.Select(Expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            paginated.Meta = new { paginated.Data.Count };
            return paginated!;
        }
    }
}

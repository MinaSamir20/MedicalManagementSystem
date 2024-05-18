using AutoMapper;
using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Application.Features.Doctors.Models;
using MedicalManagementSystem.Application.Features.Doctors.Responses;
using MedicalManagementSystem.Application.Services.Doctors;
using MedicalManagementSystem.Application.Wrappers;
using MedicalManagementSystem.Core.SharedResources;
using MedicalManagementSystem.Domain.Entities;
using Microsoft.Extensions.Localization;
using System.Linq.Expressions;

namespace MedicalManagementSystem.Application.Features.Doctors.Handler
{
    public class DoctorHandler(IMapper mapper, IDoctorService service, IStringLocalizer<SharedResources> localizer)
        : ResponseHandler(localizer),
        IRequestHandler<GetDoctorList, Response<IEnumerable<GetDoctorResponse>>>,
        IRequestHandler<GetDoctorDetails, Response<GetDoctorResponse>>,
        IRequestHandler<GetDoctorPaginatedList, PaginatedResult<GetDoctorPaginatedResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IDoctorService _service = service;
        //private readonly IStringLocalizer<SharedResources> _localizer = localizer;

        public async Task<Response<IEnumerable<GetDoctorResponse>>> Handle(GetDoctorList request, CancellationToken cancellationToken)
        {
            var patient = await _service.GetAll();
            return Success(_mapper.Map<IEnumerable<GetDoctorResponse>>(patient));
        }

        public async Task<Response<GetDoctorResponse>> Handle(GetDoctorDetails request, CancellationToken cancellationToken)
        {
            var patient = await _service.Get(a => a.Id == request.Id, null);

            return patient == null ? NotFound<GetDoctorResponse>("") : Success(_mapper.Map<GetDoctorResponse>(patient));
        }

        public async Task<PaginatedResult<GetDoctorPaginatedResponse>> Handle(GetDoctorPaginatedList request, CancellationToken cancellationToken)
        {
            Expression<Func<Doctor, GetDoctorPaginatedResponse>> Expression = e => new GetDoctorPaginatedResponse(e.Id, e.NameEn);
            var filter = _service.Filter(request.SearchBy, request.Search, request.OrderBy, request.OrderType!);
            var paginated = await filter.Select(Expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            paginated.Meta = new { paginated.Data.Count };
            return paginated!;
        }
    }
}

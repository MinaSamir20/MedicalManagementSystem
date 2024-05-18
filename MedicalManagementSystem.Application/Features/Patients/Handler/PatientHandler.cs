using AutoMapper;
using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Application.Features.Patients.Models;
using MedicalManagementSystem.Application.Features.Patients.Responses;
using MedicalManagementSystem.Application.Services.Patients;
using MedicalManagementSystem.Application.Wrappers;
using MedicalManagementSystem.Core.SharedResources;
using MedicalManagementSystem.Domain.Entities;
using Microsoft.Extensions.Localization;
using System.Linq.Expressions;

namespace MedicalManagementSystem.Application.Features.Patients.Handler
{
    public class PatientHandler(IMapper mapper, IPatientService service, IStringLocalizer<SharedResources> localizer)
        : ResponseHandler(localizer),
        IRequestHandler<GetPatientList, Response<IEnumerable<GetPatientResponse>>>,
        IRequestHandler<GetPatientDetails, Response<GetPatientResponse>>,
        IRequestHandler<GetPatientPaginatedList, PaginatedResult<GetPatientPaginatedResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IPatientService _service = service;

        public async Task<Response<IEnumerable<GetPatientResponse>>> Handle(GetPatientList request, CancellationToken cancellationToken)
        {
            var patient = await _service.GetAll();
            return Success(_mapper.Map<IEnumerable<GetPatientResponse>>(patient));
        }

        public async Task<Response<GetPatientResponse>> Handle(GetPatientDetails request, CancellationToken cancellationToken)
        {
            var patient = await _service.Get(a => a.Id == request.Id, null);

            return patient == null ? NotFound<GetPatientResponse>() : Success(_mapper.Map<GetPatientResponse>(patient));
        }

        public async Task<PaginatedResult<GetPatientPaginatedResponse>> Handle(GetPatientPaginatedList request, CancellationToken cancellationToken)
        {
            Expression<Func<Patient, GetPatientPaginatedResponse>> Expression = e => new GetPatientPaginatedResponse(e.Id, e.NameEn, e.InsuranceInfo, e.Address!.AreaName, e.Room!.RoomName);
            var filter = _service.Filter(request.SearchBy, request.Search, request.OrderBy, request.OrderType!);
            var paginated = await filter.Select(Expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            paginated.Meta = new { paginated.Data.Count };
            return paginated!;
        }
    }
}

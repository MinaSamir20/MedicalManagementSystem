using AutoMapper;
using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Application.Features.Departments.Models;
using MedicalManagementSystem.Application.Services.Departments;
using MedicalManagementSystem.Core.SharedResources;
using MedicalManagementSystem.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace MedicalManagementSystem.Application.Features.Departments.Handler
{
    public class DepartmentCommandHandler(IDepartmentService service, IMapper mapper, IStringLocalizer<SharedResources> localizer)
        : ResponseHandler(localizer),
        IRequestHandler<CreateDepartment, Response<string>>,
        IRequestHandler<UpdateDepartment, Response<string>>,
        IRequestHandler<DeleteDepartment, Response<string>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IDepartmentService _service = service;
        private readonly IStringLocalizer<SharedResources> _localizer = localizer;

        public async Task<Response<string>> Handle(CreateDepartment request, CancellationToken cancellationToken)
        {
            var speciality = _mapper.Map<Department>(request);
            await _service.Add(speciality, request.UserName!);
            return Success<string>(_localizer[SharedResourcesKeys.Added]);
        }

        public async Task<Response<string>> Handle(UpdateDepartment request, CancellationToken cancellationToken)
        {
            var specialities = _service.Get(request.Id);
            if (specialities == null) return NotFound<string>($"Department {_localizer[SharedResourcesKeys.NotFound]}");
            var response = _mapper.Map<Department>(request);
            var result = await _service.Edit(response, request.UserName!);
            if (result == "Updated") return Success<string>(_localizer[SharedResourcesKeys.Updated]);
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteDepartment request, CancellationToken cancellationToken)
        {
            await _service.Remove(request.SpecialityId, request.UserName!);
            return Deleted<string>(_localizer[SharedResourcesKeys.Deleted]);
        }
    }
}

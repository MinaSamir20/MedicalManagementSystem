using AutoMapper;
using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Application.Features.Specialities.Models;
using MedicalManagementSystem.Application.Services.Specialities;
using MedicalManagementSystem.Core.SharedResources;
using MedicalManagementSystem.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace MedicalManagementSystem.Application.Features.Specialities.Handler
{
    public class SpecialityCommandHandler(ISpecialitiesService service, IMapper mapper, IStringLocalizer<SharedResources> localizer)
        : ResponseHandler(localizer),
        IRequestHandler<CreateSpeciality, Response<string>>,
        IRequestHandler<UpdateSpeciality, Response<string>>,
        IRequestHandler<DeleteSpeciality, Response<string>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ISpecialitiesService _service = service;
        private readonly IStringLocalizer<SharedResources> _localizer = localizer;

        public async Task<Response<string>> Handle(CreateSpeciality request, CancellationToken cancellationToken)
        {
            var speciality = _mapper.Map<Speciality>(request);
            await _service.Add(speciality, request.UserName!);
            return Success<string>(_localizer[SharedResourcesKeys.Added]);
        }

        public async Task<Response<string>> Handle(UpdateSpeciality request, CancellationToken cancellationToken)
        {
            var specialities = _service.Get(request.Id);
            if (specialities == null) return NotFound<string>($"Speciality {_localizer[SharedResourcesKeys.NotFound]}");
            var response = _mapper.Map<Speciality>(request);
            var result = await _service.Edit(response, request.UserName!);
            if (result == "Updated") return Success<string>(_localizer[SharedResourcesKeys.Updated]);
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteSpeciality request, CancellationToken cancellationToken)
        {
            await _service.Remove(request.SpecialityId, request.UserName!);
            return Deleted<string>(_localizer[SharedResourcesKeys.Deleted]);
        }
    }
}

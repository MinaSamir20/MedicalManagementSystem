using AutoMapper;
using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Application.Features.Patients.Models;
using MedicalManagementSystem.Application.Services.Patients;
using MedicalManagementSystem.Core.SharedResources;
using MedicalManagementSystem.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace MedicalManagementSystem.Application.Features.Patients.Handler
{
    public class PatientCommandHandler(IPatientService service, IMapper mapper, IStringLocalizer<SharedResources> localizer)
        : ResponseHandler(localizer),
        IRequestHandler<CreatePatient, Response<string>>,
        IRequestHandler<UpdatePatient, Response<string>>,
        IRequestHandler<DeletePatient, Response<string>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IPatientService _service = service;

        public async Task<Response<string>> Handle(CreatePatient request, CancellationToken cancellationToken)
        {
            var user = await _service.Get(p => p.User.Id == request.UserId);
            if (user != null)
                return UnprocessableEntity<string>("");
            else if (user == null)
            {
                var patient = _mapper.Map<Patient>(request);
                var result = await _service.Add(patient, request.UserName!);
                return Success("");
            }
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(UpdatePatient request, CancellationToken cancellationToken)
        {
            var patient = _service.Get(request.Id);
            if (patient == null) return NotFound<string>("");
            var response = _mapper.Map<Patient>(request);
            var result = await _service.Edit(response, request.UserName!);
            if (result == "Updated") return Success("");
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeletePatient request, CancellationToken cancellationToken)
        {
            await _service.Remove(request.PatientId, request.UserName!);
            return Deleted<string>();
        }
    }
}

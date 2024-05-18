using AutoMapper;
using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Application.Features.Doctors.Models;
using MedicalManagementSystem.Application.Services.Doctors;
using MedicalManagementSystem.Core.SharedResources;
using MedicalManagementSystem.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace MedicalManagementSystem.Application.Features.Doctors.Handler
{
    public class DoctorCommandHandler(IDoctorService service, IMapper mapper, IStringLocalizer<SharedResources> localizer)
        : ResponseHandler(localizer),
        IRequestHandler<CreateDoctor, Response<string>>,
        IRequestHandler<UpdateDoctor, Response<string>>,
        IRequestHandler<DeleteDoctor, Response<string>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IDoctorService _service = service;
        //private readonly IStringLocalizer<SharedResources> _localizer = localizer;

        public async Task<Response<string>> Handle(CreateDoctor request, CancellationToken cancellationToken)
        {

            var user = await _service.Get(p => p.User.Id == request.UserId);
            if (user != null)
                return UnprocessableEntity<string>("");
            else if (user == null)
            {
                var doctor = _mapper.Map<Doctor>(request);
                var result = await _service.Add(doctor, request.UserName!);
                return Created("");
            }
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(UpdateDoctor request, CancellationToken cancellationToken)
        {
            var pateint = _service.Get(request.Id);
            if (pateint == null) return NotFound<string>("");
            var doctor = _mapper.Map<Doctor>(request);
            var result = await _service.Edit(doctor, request.UserName!);
            if (result == "Updated") return Success("");
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteDoctor request, CancellationToken cancellationToken)
        {
            await _service.Remove(request.DoctorId, request.UserName!);
            return Deleted<string>();
        }
    }
}

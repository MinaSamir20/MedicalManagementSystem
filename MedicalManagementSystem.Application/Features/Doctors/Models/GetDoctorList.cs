using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Application.Features.Doctors.Responses;

namespace MedicalManagementSystem.Application.Features.Doctors.Models
{
    public class GetDoctorList : IRequest<Response<IEnumerable<GetDoctorResponse>>>
    {
    }
}

using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Application.Features.Doctors.Responses;

namespace MedicalManagementSystem.Application.Features.Doctors.Models
{
    public class GetDoctorDetails(int id) : IRequest<Response<GetDoctorResponse>>
    {
        public int Id { get; set; } = id;
    }
}

using MediatR;
using MedicalManagementSystem.Application.Bases;

namespace MedicalManagementSystem.Application.Features.Doctors.Models
{
    public class DeleteDoctor() : IRequest<Response<string>>
    {
        public int DoctorId { get; set; }
        public string? UserName { get; set; }
    }
}

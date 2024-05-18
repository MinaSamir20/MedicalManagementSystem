using MediatR;
using MedicalManagementSystem.Application.Bases;

namespace MedicalManagementSystem.Application.Features.Patients.Models
{
    public class DeletePatient : IRequest<Response<string>>
    {
        public int PatientId { get; set; }
        public string? UserName { get; set; }
    }
}

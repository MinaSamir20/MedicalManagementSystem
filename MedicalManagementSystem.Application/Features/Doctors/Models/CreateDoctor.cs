using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Domain.ValueObject;

namespace MedicalManagementSystem.Application.Features.Doctors.Models
{
    public class CreateDoctor : IRequest<Response<string>>
    {
        public float ChargesPerVisit { get; set; }
        public float ReputeIndex { get; set; }
        public int Patients_Treated { get; set; }
        public Address? Address { get; set; }
        public int SpecialityId { get; set; }
        public string ClinicName { get; set; } = string.Empty;

        public string? UserId { get; set; }
        public string? UserName { get; set; }

    }
}

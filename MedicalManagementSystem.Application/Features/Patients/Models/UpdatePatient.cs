using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Application.DTOs;
using MedicalManagementSystem.Domain.ValueObject;

namespace MedicalManagementSystem.Application.Features.Patients.Models
{
    public class UpdatePatient : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? InsuranceInfo { get; set; }
        public Address? Address { get; set; }
        public int RoomId { get; set; }
        public string? UserName { get; set; }

        public IEnumerable<TreatmentDto>? Treatments { get; set; }
    }
}

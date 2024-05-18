#nullable disable
using MedicalManagementSystem.Application.DTOs;
using MedicalManagementSystem.Application.DTOs.Authentication;
using MedicalManagementSystem.Domain.Entities;
using MedicalManagementSystem.Domain.ValueObject;

namespace MedicalManagementSystem.Application.Features.Patients.Responses
{
    public class GetPatientResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserDto User { get; set; }
        public string InsuranceInfo { get; set; }
        public Address Address { get; set; }
        public Room Room { get; set; }
        public IEnumerable<AppointmentDto> Appointments { get; set; }
        public IEnumerable<BillDto> Bills { get; set; }
        public IEnumerable<TreatmentDto> Treatments { get; set; }
    }
}

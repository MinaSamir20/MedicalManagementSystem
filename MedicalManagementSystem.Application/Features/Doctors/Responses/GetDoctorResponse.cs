#nullable disable
using MedicalManagementSystem.Application.DTOs.Authentication;
using MedicalManagementSystem.Domain.Entities;

namespace MedicalManagementSystem.Application.Features.Doctors.Responses
{
    public class GetDoctorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float ChargesPerVisit { get; set; }
        public float ReputeIndex { get; set; }
        public int Patients_Treated { get; set; }

        public UserDto User { get; set; }
        public string ClinicName { get; set; }
        public string SpecialityName { get; set; }

        public IEnumerable<AvilableAppointment> AvilableAppointments { get; set; }
        public IEnumerable<Prescription> Prescriptions { get; set; }
    }
}

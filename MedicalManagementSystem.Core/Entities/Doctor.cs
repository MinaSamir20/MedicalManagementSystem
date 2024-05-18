#nullable disable
namespace MedicalManagementSystem.Domain.Entities
{
    public class Doctor : Staff
    {
        public float ChargesPerVisit { get; set; }
        public float ReputeIndex { get; set; }
        public int Patients_Treated { get; set; }

        /*-------- Relations --------*/

        public Clinic Clinic { get; set; }

        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }

        public ICollection<AvilableAppointment> AvilableAppointments { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
#nullable disable
namespace MedicalManagementSystem.Domain.Entities
{
    public class Prescription : BaseEntity
    {
        public DateTime DatePrescribed { get; set; }
        public string AdditionalNotes { get; set; }

        /*-------- Relations --------*/
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public ICollection<PrescriptionDetail> PrescriptionDetails { get; set; }
    }
}

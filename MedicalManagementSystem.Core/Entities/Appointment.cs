#nullable disable
namespace MedicalManagementSystem.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public bool Approved { get; set; }
        public string Progress { get; set; }

        /*-------- Relations --------*/
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public Bill Bill { get; set; }

        public Prescription Prescription { get; set; }

        public AvilableAppointment AvilableAppointment { get; set; }
    }
}
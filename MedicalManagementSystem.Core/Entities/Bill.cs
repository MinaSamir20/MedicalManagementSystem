#nullable disable
namespace MedicalManagementSystem.Domain.Entities
{
    public class Bill : BaseEntity
    {
        public DateTime? BillDate { get; set; }
        public float Amount { get; set; }
        public bool Status { get; set; }

        /*-------- Relations --------*/

        public int AppointmentId { get; set; } = 0;
        public Appointment Appointment { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
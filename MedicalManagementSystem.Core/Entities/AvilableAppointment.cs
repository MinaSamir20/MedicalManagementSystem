#nullable disable
namespace MedicalManagementSystem.Domain.Entities
{
    public class AvilableAppointment : BaseEntity
    {
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public float BillAmount { get; set; }

        /*-------- Relations --------*/

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

    }
}

using MedicalManagementSystem.Domain.ValueObject;

namespace MedicalManagementSystem.Domain.Entities
{
    public class Patient : UserEntity
    {
        public string InsuranceInfo { get; set; } = string.Empty;

        /*-------- Relations --------*/
        public Address? Address { get; set; }

        public int RoomId { get; set; } = 0;
        public Room? Room { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; } = Enumerable.Empty<Appointment>();
        public IEnumerable<Bill> Bills { get; set; } = Enumerable.Empty<Bill>();
        public IEnumerable<Treatment> Treatments { get; set; } = Enumerable.Empty<Treatment>();
        public IEnumerable<Prescription> Prescriptions { get; set; } = Enumerable.Empty<Prescription>();
    }
}

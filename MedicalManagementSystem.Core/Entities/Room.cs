#nullable disable
namespace MedicalManagementSystem.Domain.Entities
{
    public class Room : BaseEntity
    {
        public string RoomName { get; set; }
        public int FloorNumber { get; set; }
        public int NumberOfAllBeds { get; set; }
        public int NumberOfTakenBeds { get; set; }

        /*-------- Relations --------*/
        public ICollection<Patient> Patients { get; set; }
    }
}

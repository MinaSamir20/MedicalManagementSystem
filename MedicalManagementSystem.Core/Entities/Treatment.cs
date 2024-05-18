#nullable disable
namespace MedicalManagementSystem.Domain.Entities
{
    public class Treatment : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        /*-------- Relations --------*/
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
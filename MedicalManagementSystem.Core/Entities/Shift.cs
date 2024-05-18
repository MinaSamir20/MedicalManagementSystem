#nullable disable
namespace MedicalManagementSystem.Domain.Entities
{
    public class Shift : BaseEntity
    {
        public DateOnly Date { get; set; }
        public TimeOnly ShiftStart { get; set; }
        public TimeOnly ShiftEnd { get; set; }

        /*-------- Relations --------*/
        public IEnumerable<MedicalStaff> Staffs { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
    }
}

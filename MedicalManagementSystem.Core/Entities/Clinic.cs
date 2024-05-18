#nullable disable
using MedicalManagementSystem.Domain.Commands;

namespace MedicalManagementSystem.Domain.Entities
{
    public class Clinic : LocalizableEntities
    {
        public string ClNameEn { get; set; }
        public string ClNameAr { get; set; }
        public int FloorNumber { get; set; }
        public TimeOnly WorkingStartTime { get; set; }
        public TimeOnly WorkingEndTime { get; set; }

        /*-------- Relations --------*/

        public Doctor Doctor { get; set; }
    }
}

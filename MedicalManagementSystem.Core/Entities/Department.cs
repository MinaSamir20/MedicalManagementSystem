#nullable disable
using MedicalManagementSystem.Domain.Commands;

namespace MedicalManagementSystem.Domain.Entities
{
    public class Department : LocalizableEntities
    {
        public string DNameEn { get; set; }
        public string DNameAr { get; set; }
        public string Description { get; set; }
        public int NoOfDoctor { get; set; }

        /*-------- Relations --------*/
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<MedicalStaff> Staffs { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}

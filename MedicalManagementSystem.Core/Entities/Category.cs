#nullable disable
using MedicalManagementSystem.Domain.Commands;

namespace MedicalManagementSystem.Domain.Entities
{
    public class Category : LocalizableEntities
    {
        public string CNameEn { get; set; }
        public string CNameAr { get; set; }
        /*-------- Relations --------*/
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}

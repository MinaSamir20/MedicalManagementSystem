#nullable disable
using MedicalManagementSystem.Domain.Commands;
using MedicalManagementSystem.Domain.Entities.Identity;
using MedicalManagementSystem.Domain.Enums;

namespace MedicalManagementSystem.Domain.Entities
{
    public class UserEntity : LocalizableEntities
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string NationalID { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }

        /*-------- Relations --------*/

        public string UserId { get; set; }
        public User User { get; set; }
    }
}

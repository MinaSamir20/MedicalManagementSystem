#nullable disable
using MedicalManagementSystem.Domain.Commands;

namespace MedicalManagementSystem.Domain.Entities
{
    public class Speciality : LocalizableEntities
    {

        public string SNameEn { get; set; }
        public string SNameAr { get; set; }
        /*-------- Relations --------*/
        public ICollection<Doctor> Doctors { get; set; }
    }
}

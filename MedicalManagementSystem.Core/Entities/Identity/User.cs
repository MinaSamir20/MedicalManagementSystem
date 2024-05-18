using Microsoft.AspNetCore.Identity;

namespace MedicalManagementSystem.Domain.Entities.Identity
{
    public class User : IdentityUser
    {
        public User()
        {
            Patient = new HashSet<Patient>();
            Staff = new HashSet<MedicalStaff>();
        }

        public string? ImageUrl { get; set; }
        public List<RefreshToken>? RefreshTokens { get; set; }

        /*-------- Relations --------*/
        public virtual ICollection<Patient> Patient { get; set; }
        public virtual ICollection<MedicalStaff> Staff { get; set; }
    }
}

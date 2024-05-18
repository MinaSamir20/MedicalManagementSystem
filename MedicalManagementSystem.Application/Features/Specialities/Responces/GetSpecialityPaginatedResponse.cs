#nullable disable
namespace MedicalManagementSystem.Application.Features.Specialities.Responces
{
    public class GetSpecialityPaginatedResponse(int id, string specialityName)
    {
        public int Id { get; set; } = id;
        public string SpecialityName { get; set; } = specialityName;
    }
}

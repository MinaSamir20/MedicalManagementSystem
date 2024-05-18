#nullable disable
namespace MedicalManagementSystem.Application.Features.Departments.Responces
{
    public class GetDepartmentPaginatedResponse(int id, string specialityName)
    {
        public int Id { get; set; } = id;
        public string SpecialityName { get; set; } = specialityName;
    }
}

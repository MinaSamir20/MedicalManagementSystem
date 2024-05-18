#nullable disable
namespace MedicalManagementSystem.Application.Features.Doctors.Responses
{
    public class GetDoctorPaginatedResponse(int id, string name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
    }
}

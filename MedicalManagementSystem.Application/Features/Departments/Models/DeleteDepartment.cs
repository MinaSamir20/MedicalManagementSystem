using MediatR;
using MedicalManagementSystem.Application.Bases;

namespace MedicalManagementSystem.Application.Features.Departments.Models
{
    public class DeleteDepartment : IRequest<Response<string>>
    {
        public int SpecialityId { get; set; }
        public string? UserName { get; set; }
    }
}

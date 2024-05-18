using MediatR;
using MedicalManagementSystem.Application.Bases;

namespace MedicalManagementSystem.Application.Features.Departments.Models
{
    public class CreateDepartment : IRequest<Response<string>>
    {
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? UserName { get; set; }
    }
}

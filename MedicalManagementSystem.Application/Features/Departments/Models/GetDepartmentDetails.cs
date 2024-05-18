using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Application.Features.Departments.Responces;

namespace MedicalManagementSystem.Application.Features.Departments.Models
{
    public class GetDepartmentDetails(int id) : IRequest<Response<GetDepartmentResponse>>
    {
        public int Id { get; set; } = id;
    }
}

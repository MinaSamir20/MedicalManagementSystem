using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Application.Features.Departments.Responces;

namespace MedicalManagementSystem.Application.Features.Departments.Models
{
    public class GetDepartmentList : IRequest<Response<IEnumerable<GetDepartmentResponse>>>
    {
    }
}

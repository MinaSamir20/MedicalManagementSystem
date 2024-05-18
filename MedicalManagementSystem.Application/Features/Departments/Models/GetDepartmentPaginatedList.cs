using MediatR;
using MedicalManagementSystem.Application.Features.Departments.Responces;
using MedicalManagementSystem.Application.Wrappers;

namespace MedicalManagementSystem.Application.Features.Departments.Models
{
    public class GetDepartmentPaginatedList : IRequest<PaginatedResult<GetDepartmentPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? OrderBy { get; set; }
        public string? OrderType { get; set; }
        public string? Search { get; set; }
        public string? SearchBy { get; set; }
    }
}

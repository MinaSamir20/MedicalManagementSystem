using MediatR;
using MedicalManagementSystem.Application.Features.Specialities.Responces;
using MedicalManagementSystem.Application.Wrappers;

namespace MedicalManagementSystem.Application.Features.Specialities.Models
{
    public class GetSpecialityPaginatedList : IRequest<PaginatedResult<GetSpecialityPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? OrderBy { get; set; }
        public string? OrderType { get; set; }
        public string? Search { get; set; }
        public string? SearchBy { get; set; }
    }
}

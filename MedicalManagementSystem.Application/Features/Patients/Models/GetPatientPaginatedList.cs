using MediatR;
using MedicalManagementSystem.Application.Features.Patients.Responses;
using MedicalManagementSystem.Application.Wrappers;

namespace MedicalManagementSystem.Application.Features.Patients.Models
{
    public class GetPatientPaginatedList : IRequest<PaginatedResult<GetPatientPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? OrderBy { get; set; }
        public string? OrderType { get; set; }
        public string? Search { get; set; }
        public string? SearchBy { get; set; }
    }
}

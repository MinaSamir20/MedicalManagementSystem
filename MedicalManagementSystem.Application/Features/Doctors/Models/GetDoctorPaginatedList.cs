using MediatR;
using MedicalManagementSystem.Application.Features.Doctors.Responses;
using MedicalManagementSystem.Application.Wrappers;

namespace MedicalManagementSystem.Application.Features.Doctors.Models
{
    public class GetDoctorPaginatedList : IRequest<PaginatedResult<GetDoctorPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? OrderBy { get; set; }
        public string? OrderType { get; set; }
        public string? Search { get; set; }
        public string? SearchBy { get; set; }
    }
}

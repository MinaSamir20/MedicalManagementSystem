using MediatR;
using MedicalManagementSystem.Application.Bases;

namespace MedicalManagementSystem.Application.Features.Specialities.Models
{
    public class UpdateSpeciality : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? UserName { get; set; }
    }
}

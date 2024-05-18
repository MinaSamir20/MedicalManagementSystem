using MediatR;
using MedicalManagementSystem.Application.Bases;

namespace MedicalManagementSystem.Application.Features.Specialities.Models
{
    public class CreateSpeciality : IRequest<Response<string>>
    {
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? UserName { get; set; }
    }
}

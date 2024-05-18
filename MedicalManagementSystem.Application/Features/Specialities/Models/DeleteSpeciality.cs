using MediatR;
using MedicalManagementSystem.Application.Bases;

namespace MedicalManagementSystem.Application.Features.Specialities.Models
{
    public class DeleteSpeciality : IRequest<Response<string>>
    {
        public int SpecialityId { get; set; }
        public string? UserName { get; set; }
    }
}

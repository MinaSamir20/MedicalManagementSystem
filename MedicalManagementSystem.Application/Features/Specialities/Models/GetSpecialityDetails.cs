using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Application.Features.Specialities.Responces;

namespace MedicalManagementSystem.Application.Features.Specialities.Models
{
    public class GetSpecialityDetails(int id) : IRequest<Response<GetSpecialityResponse>>
    {
        public int Id { get; set; } = id;
    }
}

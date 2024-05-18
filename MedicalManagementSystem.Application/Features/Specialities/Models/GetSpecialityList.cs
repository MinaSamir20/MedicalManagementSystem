using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Application.Features.Specialities.Responces;

namespace MedicalManagementSystem.Application.Features.Specialities.Models
{
    public class GetSpecialityList : IRequest<Response<IEnumerable<GetSpecialityResponse>>>
    {
    }
}

using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Application.Features.Patients.Responses;

namespace MedicalManagementSystem.Application.Features.Patients.Models
{
    public class GetPatientList : IRequest<Response<IEnumerable<GetPatientResponse>>>
    {
    }
}

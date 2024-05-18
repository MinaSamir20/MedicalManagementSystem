using MediatR;
using MedicalManagementSystem.Application.Bases;
using MedicalManagementSystem.Application.Features.Patients.Responses;

namespace MedicalManagementSystem.Application.Features.Patients.Models
{
    public class GetPatientDetails(int id) : IRequest<Response<GetPatientResponse>>
    {
        public int Id { get; set; } = id;
    }
}

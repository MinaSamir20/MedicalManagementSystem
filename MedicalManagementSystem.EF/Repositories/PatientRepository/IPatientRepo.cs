using MedicalManagementSystem.Domain.Entities;
using MedicalManagementSystem.Infrasturcture.Repositories.BaseRepository;

namespace MedicalManagementSystem.Infrasturcture.Repositories.PatientRepository
{
    public interface IPatientRepo : IBaseRepo<Patient>
    {
    }
}

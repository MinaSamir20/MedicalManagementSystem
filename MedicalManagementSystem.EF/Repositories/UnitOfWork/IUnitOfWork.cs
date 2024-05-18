using MedicalManagementSystem.Domain.Entities;
using MedicalManagementSystem.Infrasturcture.Repositories.BaseRepository;
using MedicalManagementSystem.Infrasturcture.Repositories.PatientRepository;

namespace MedicalManagementSystem.Infrasturcture.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepo Patients { get; }
        IBaseRepo<Doctor> Doctors { get; }
        IBaseRepo<Speciality> Specialities { get; }
        IBaseRepo<Department> Departments { get; }
        IBaseRepo<Room> Rooms { get; }
        IBaseRepo<Category> Categories { get; }

        int Complete();
    }
}

using MedicalManagementSystem.Domain.Entities;
using MedicalManagementSystem.Infrastructure.Database;
using MedicalManagementSystem.Infrasturcture.Repositories.BaseRepository;

namespace MedicalManagementSystem.Infrasturcture.Repositories.PatientRepository
{
    public class PatientRepo(AppDbContext db) : BaseRepo<Patient>(db), IPatientRepo
    {
        //private readonly AppDbContext _db = db;
    }
}

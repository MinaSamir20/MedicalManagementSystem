using MedicalManagementSystem.Domain.Entities;
using MedicalManagementSystem.Infrastructure.Database;
using MedicalManagementSystem.Infrasturcture.Repositories.BaseRepository;
using MedicalManagementSystem.Infrasturcture.Repositories.PatientRepository;


namespace MedicalManagementSystem.Infrasturcture.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public IPatientRepo Patients { get; private set; }
        public IBaseRepo<Doctor> Doctors { get; private set; }
        public IBaseRepo<Speciality> Specialities { get; private set; }

        public IBaseRepo<Department> Departments { get; private set; }

        public IBaseRepo<Room> Rooms { get; private set; }

        public IBaseRepo<Category> Categories { get; private set; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Departments = new BaseRepo<Department>(_db);
            Rooms = new BaseRepo<Room>(_db);
            Categories = new BaseRepo<Category>(_db);
            Patients = new PatientRepo(_db);
            Doctors = new BaseRepo<Doctor>(_db);
            Specialities = new BaseRepo<Speciality>(_db);
        }

        public int Complete() => _db.SaveChanges();

        public void Dispose() => _db.Dispose();
    }
}

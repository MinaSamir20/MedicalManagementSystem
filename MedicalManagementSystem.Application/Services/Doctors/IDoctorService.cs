using MedicalManagementSystem.Domain.Consts;
using MedicalManagementSystem.Domain.Entities;
using System.Linq.Expressions;

namespace MedicalManagementSystem.Application.Services.Doctors
{
    public interface IDoctorService
    {
        Task<string> Add(Doctor doctor, string username);
        Task<string> Add(IEnumerable<Doctor> doctors, string username);

        IQueryable<Doctor> Get(int? id);
        Task<bool> IsDoctorExists(bool isAr, string name);
        Task<Doctor> Get(Expression<Func<Doctor, bool>> criteria, string[]? includes = null);
        Task<IEnumerable<Doctor>> GetAll(Expression<Func<Doctor, bool>>? criteria = null, string[]? includes = null);

        IQueryable<Doctor> Filter(string? searchBy, string? search, string? orderBy, string OrderByDirection = OrderBy.Ascending);

        Task<string> Edit(Doctor doctor, string username);
        Task<string> Edit(IEnumerable<Doctor> doctors, string username);

        Task<string> Remove(int id, string username);
        Task<string> Remove(IEnumerable<int> ids, string username);
    }
}

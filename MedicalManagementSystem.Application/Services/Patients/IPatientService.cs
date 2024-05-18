using MedicalManagementSystem.Domain.Consts;
using MedicalManagementSystem.Domain.Entities;
using System.Linq.Expressions;

namespace MedicalManagementSystem.Application.Services.Patients
{
    public interface IPatientService
    {
        Task<string> Add(Patient patient, string username);
        Task<string> Add(IEnumerable<Patient> patients, string username);

        IQueryable<Patient> Get(int? id);
        Task<bool> IsPatientExists(bool isAr, string name);
        Task<Patient> Get(Expression<Func<Patient, bool>> criteria, string[]? includes = null);
        Task<IEnumerable<Patient>> GetAll(Expression<Func<Patient, bool>>? criteria = null, string[]? includes = null);

        IQueryable<Patient> Filter(string? searchBy, string? search, string? orderBy, string OrderByDirection = OrderBy.Ascending);

        Task<string> Edit(Patient patient, string username);
        Task<string> Edit(IEnumerable<Patient> patients, string username);

        Task<string> Remove(int id, string username);
        Task<string> Remove(IEnumerable<int> ids, string username);
    }
}

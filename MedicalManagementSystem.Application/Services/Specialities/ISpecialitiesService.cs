using MedicalManagementSystem.Domain.Consts;
using MedicalManagementSystem.Domain.Entities;
using System.Linq.Expressions;

namespace MedicalManagementSystem.Application.Services.Specialities
{
    public interface ISpecialitiesService
    {
        Task<string> Add(Speciality speciality, string username);
        Task<string> Add(IEnumerable<Speciality> specialities, string username);

        IQueryable<Speciality> Get(int? id);
        Task<bool> IsSpecialityExists(bool isAr, string name);
        Task<Speciality> Get(Expression<Func<Speciality, bool>> criteria, string[]? includes = null);
        Task<IEnumerable<Speciality>> GetAll(Expression<Func<Speciality, bool>>? criteria = null, string[]? includes = null);

        IQueryable<Speciality> Filter(string? searchBy, string? search, string? orderBy, string OrderByDirection = OrderBy.Ascending);

        Task<string> Edit(Speciality speciality, string username);
        Task<string> Edit(IEnumerable<Speciality> specialities, string username);

        Task<string> Remove(int id, string username);
        Task<string> Remove(IEnumerable<int> ids, string username);
    }
}

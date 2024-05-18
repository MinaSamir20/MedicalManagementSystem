using MedicalManagementSystem.Domain.Consts;
using MedicalManagementSystem.Domain.Entities;
using System.Linq.Expressions;

namespace MedicalManagementSystem.Application.Services.Departments
{
    public interface IDepartmentService
    {
        Task<string> Add(Department command, string username);
        Task<string> Add(IEnumerable<Department> commands, string username);

        IQueryable<Department> Get(int? id);
        Task<bool> IsDepartmentExists(bool isAr, string name);
        Task<Department> Get(Expression<Func<Department, bool>> criteria, string[]? includes = null);
        Task<IEnumerable<Doctor>> GetAll(Expression<Func<Department, bool>>? criteria = null, string[]? includes = null);

        IQueryable<Department> Filter(string? searchBy, string? search, string? orderBy, string OrderByDirection = OrderBy.Ascending);

        Task<string> Edit(Department command, string username);
        Task<string> Edit(IEnumerable<Department> commands, string username);

        Task<string> Remove(int id, string username);
        Task<string> Remove(IEnumerable<int> ids, string username);
    }
}

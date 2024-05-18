using MedicalManagementSystem.Domain.Entities;
using MedicalManagementSystem.Infrasturcture.Repositories.UnitOfWork;
using System.Linq.Expressions;

namespace MedicalManagementSystem.Application.Services.Departments
{
    public class DepartmentService(IUnitOfWork unit) : IDepartmentService
    {
        private readonly IUnitOfWork _unit = unit;

        public Task<string> Add(Department command, string username)
        {
            throw new NotImplementedException();
        }

        public Task<string> Add(IEnumerable<Department> commands, string username)
        {
            throw new NotImplementedException();
        }

        public Task<string> Edit(Department command, string username)
        {
            throw new NotImplementedException();
        }

        public Task<string> Edit(IEnumerable<Department> commands, string username)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Department> Filter(string? searchBy, string? search, string? orderBy, string OrderByDirection = "ASC")
        {
            throw new NotImplementedException();
        }

        public IQueryable<Department> Get(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Department> Get(Expression<Func<Department, bool>> criteria, string[]? includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Doctor>> GetAll(Expression<Func<Department, bool>>? criteria = null, string[]? includes = null)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsDepartmentExists(bool isAr, string name)
        {
            Expression<Func<Department, bool>> expression = isAr == true ? (a => a.DNameAr.Equals(name)) : (a => a.DNameEn.Equals(name));
            var check = await _unit.Departments.GetAsync(expression, null);
            if (check != null) return false;
            return true;
        }

        public Task<string> Remove(int id, string username)
        {
            throw new NotImplementedException();
        }

        public Task<string> Remove(IEnumerable<int> ids, string username)
        {
            throw new NotImplementedException();
        }
    }
}

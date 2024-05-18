using MedicalManagementSystem.Domain.Entities;
using MedicalManagementSystem.Domain.Entities.Identity;
using MedicalManagementSystem.Infrasturcture.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace MedicalManagementSystem.Application.Services.Specialities
{
    public class SpecialitiesService(IUnitOfWork unit, UserManager<User> userManager) : ISpecialitiesService
    {
        private readonly IUnitOfWork _unit = unit;
        private readonly UserManager<User> _userManager = userManager;

        public async Task<string> Add(Speciality speciality, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                await _unit.Specialities.CreateAsync(speciality, username);
                _unit.Complete();
                return "Success";
            }
            return "Invalid User";
        }

        public async Task<string> Add(IEnumerable<Speciality> specialities, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                await _unit.Specialities.CreateAsync(specialities, username);
                _unit.Complete();
                return "Success";
            }
            return "Invalid User";
        }

        public async Task<string> Edit(Speciality speciality, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                await _unit.Specialities.Update(speciality, username);
                _unit.Complete();
                return "Success";
            }
            return "Invalid User";
        }

        public async Task<string> Edit(IEnumerable<Speciality> specialities, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                await _unit.Specialities.Update(specialities, username);
                _unit.Complete();
                return "Success";
            }
            return "Invalid User";
        }

        public IQueryable<Speciality> Filter(string? searchBy, string? search, string? orderBy, string OrderByDirection = "ASC")
        {
            Expression<Func<Speciality, bool>>? searchResult = searchBy switch
            {
                "SpecialityName" => a => a.GetLocalized(a.SNameEn, a.SNameAr).Contains(search!),
                _ => null,
            };
            Expression<Func<Speciality, object>>? orderResult = orderBy switch
            {
                "SpecialityName" => a => a.GetLocalized(a.SNameEn, a.SNameAr),
                _ => null,
            };
            return _unit.Specialities.FilterAllAsync(searchResult, orderResult, OrderByDirection);
        }

        public async Task<Speciality> Get(Expression<Func<Speciality, bool>> criteria, string[]? includes = null)
        {
            return await _unit.Specialities.GetAsync(criteria, includes);
        }

        public async Task<IEnumerable<Speciality>> GetAll(Expression<Func<Speciality, bool>>? criteria = null, string[]? includes = null) => await _unit.Specialities.GetAllAsync(criteria, includes);

        public IQueryable<Speciality> Get(int? id)
        {
            return _unit.Specialities.GetTableNoTracking().Where(x => x.Id == id).AsQueryable();
        }



        public async Task<string> Remove(int id, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                await _unit.Specialities.DeleteAsync(id, username);
                _unit.Complete();
                return "Success";
            }
            return "Invalid User";
        }

        public async Task<string> Remove(IEnumerable<int> ids, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                await _unit.Specialities.DeleteAsync(ids, username);
                _unit.Complete();
                return "Success";
            }
            return "Invalid User";
        }

        public async Task<bool> IsSpecialityExists(bool isAr, string name)
        {
            Expression<Func<Speciality, bool>> specialityName = isAr == true ? (a => a.SNameAr.Equals(name)) : (a => a.SNameEn.Equals(name));
            var check = await _unit.Specialities.GetAsync(specialityName, null);
            if (check != null) return false;
            return true;
        }
    }
}

using MedicalManagementSystem.Domain.Entities;
using MedicalManagementSystem.Domain.Entities.Identity;
using MedicalManagementSystem.Infrasturcture.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace MedicalManagementSystem.Application.Services.Doctors
{
    public class DoctorService(IUnitOfWork unit, UserManager<User> userManager) : IDoctorService
    {
        private readonly IUnitOfWork _unit = unit;
        private readonly UserManager<User> _userManager = userManager;

        public async Task<string> Add(Doctor doctor, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                var result = await _unit.Doctors.GetAsync(p => p.UserId == doctor.UserId, null);
                if (result is null)
                {
                    await _unit.Doctors.CreateAsync(doctor, username);
                    _unit.Complete();
                }
                return "Success";
            }
            return "Invalid User";
        }

        public async Task<string> Add(IEnumerable<Doctor> doctors, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                await _unit.Doctors.CreateAsync(doctors, username);
                _unit.Complete();
                return "Success";
            }
            return "Invalid User";
        }

        public async Task<string> Edit(Doctor doctor, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                await _unit.Doctors.Update(doctor, username);
                _unit.Complete();
                return "Success";
            }
            return "Invalid User";
        }

        public async Task<string> Edit(IEnumerable<Doctor> doctors, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                await _unit.Doctors.Update(doctors, username);
                _unit.Complete();
                return "Success";
            }
            return "Invalid User";
        }

        public IQueryable<Doctor> Filter(string? searchBy, string? search, string? orderBy, string OrderByDirection = "ASC")
        {
            Expression<Func<Doctor, bool>>? searchResult = searchBy switch
            {
                "ClinicName" => a => a.Clinic!.GetLocalized(a.Clinic.ClNameEn, a.Clinic.ClNameAr).Contains(search!),
                "Name" => a => a.GetLocalized(a.NameEn, a.NameAr).Contains(search!),
                "Phone" => a => a.User.PhoneNumber!.Contains(search!),
                //"Adress" => a => a.Address!.AreaName.Contains(search!),
                //"DOB" => a => a.DOB.ToString().Contains(search!),

                _ => null,
            };
            Expression<Func<Doctor, object>>? orderResult = orderBy switch
            {
                "ClinicName" => x => x.Clinic!.GetLocalized(x.Clinic.ClNameEn, x.Clinic.ClNameAr),
                "Name" => x => x.GetLocalized(x.NameEn, x.NameAr),
                _ => null,
            };
            return _unit.Doctors.FilterAllAsync(searchResult, orderResult, OrderByDirection);
        }

        public async Task<Doctor> Get(Expression<Func<Doctor, bool>> criteria, string[]? includes = null)
        {
            return await _unit.Doctors.GetAsync(criteria, includes);
        }

        public async Task<IEnumerable<Doctor>> GetAll(Expression<Func<Doctor, bool>>? criteria = null, string[]? includes = null)
        {
            return await _unit.Doctors.GetAllAsync(criteria, includes);
        }

        public IQueryable<Doctor> Get(int? id)
        {
            return _unit.Doctors.GetTableNoTracking().Where(x => x.Id == id).AsQueryable();
        }

        public async Task<string> Remove(int id, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                await _unit.Doctors.DeleteAsync(id, username);
                _unit.Complete();
                return "Success";
            }
            return "Invalid User";
        }

        public async Task<string> Remove(IEnumerable<int> ids, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                await _unit.Doctors.DeleteAsync(ids, username);
                _unit.Complete();
                return "Success";
            }
            return "Invalid User";
        }

        public async Task<bool> IsDoctorExists(bool isAr, string name)
        {
            Expression<Func<Doctor, bool>> expression = isAr == true ? (a => a.NameAr.Equals(name)) : (a => a.NameEn.Equals(name));
            var check = await _unit.Doctors.GetAsync(expression, null);
            if (check != null) return false;
            return true;
        }
    }
}

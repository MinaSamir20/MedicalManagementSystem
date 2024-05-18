using MedicalManagementSystem.Domain.Entities;
using MedicalManagementSystem.Domain.Entities.Identity;
using MedicalManagementSystem.Infrasturcture.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace MedicalManagementSystem.Application.Services.Patients
{
    public class PatientService(IUnitOfWork unit, UserManager<User> userManager) : IPatientService
    {
        private readonly IUnitOfWork _unit = unit;
        private readonly UserManager<User> _userManager = userManager;

        public async Task<string> Add(Patient patient, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                var result = await _unit.Patients.GetAsync(p => p.UserId == patient.UserId, null);
                if (result is null)
                {
                    await _unit.Patients.CreateAsync(patient, username);
                    _unit.Complete();
                }
                return "Success";
            }
            return "Invalid User";
        }

        public async Task<string> Add(IEnumerable<Patient> patients, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                await _unit.Patients.CreateAsync(patients, username);
                _unit.Complete();
                return "Success";
            }
            return "Invalid User";
        }

        public async Task<string> Edit(Patient patient, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                await _unit.Patients.Update(patient, username);
                _unit.Complete();
                return "Success";
            }
            return "Invalid User";
        }

        public async Task<string> Edit(IEnumerable<Patient> patients, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                await _unit.Patients.Update(patients, username);
                _unit.Complete();
                return "Success";
            }
            return "Invalid User";
        }

        public IQueryable<Patient> Filter(string? searchBy, string? search, string? orderBy, string OrderByDirection = "ASC")
        {
            Expression<Func<Patient, bool>>? searchResult = searchBy switch
            {
                "RoomName" => a => a.Room!.RoomName.Contains(search!),
                "Name" => a => a.NameEn.Contains(search!),
                "Phone" => a => a.User.PhoneNumber!.Contains(search!),
                "Adress" => a => a.Address!.AreaName.Contains(search!),
                //"DOB" => a => a.DOB.ToString().Contains(search!),
                _ => null,
            };
            Expression<Func<Patient, object>>? orderResult = orderBy switch
            {
                "RoomName" => x => x.Room!.RoomName,
                "Name" => x => x.NameEn,
                _ => null,
            };
            return _unit.Patients.FilterAllAsync(searchResult, orderResult, OrderByDirection);
        }

        public async Task<Patient> Get(Expression<Func<Patient, bool>> criteria, string[]? includes = null)
        {
            return await _unit.Patients.GetAsync(criteria, includes);
        }

        public async Task<IEnumerable<Patient>> GetAll(Expression<Func<Patient, bool>>? criteria = null, string[]? includes = null)
        {
            return await _unit.Patients.GetAllAsync(criteria, includes);
        }

        public IQueryable<Patient> Get(int? id)
        {
            return _unit.Patients.GetTableNoTracking().Where(x => x.Id == id).AsQueryable();
        }

        public async Task<string> Remove(int id, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                await _unit.Patients.DeleteAsync(id, username);
                _unit.Complete();
                return "Success";
            }
            return "Invalid User";
        }

        public async Task<string> Remove(IEnumerable<int> ids, string username)
        {
            if (await _userManager.FindByNameAsync(username) is not null)
            {
                await _unit.Patients.DeleteAsync(ids, username);
                _unit.Complete();
                return "Success";
            }
            return "Invalid User";
        }

        public async Task<bool> IsPatientExists(bool isAr, string name)
        {
            Expression<Func<Patient, bool>> expression = isAr == true ? (a => a.NameAr.Equals(name)) : (a => a.NameEn.Equals(name));
            var check = await _unit.Patients.GetAsync(expression, null);
            if (check != null) return false;
            return true;
        }
    }
}

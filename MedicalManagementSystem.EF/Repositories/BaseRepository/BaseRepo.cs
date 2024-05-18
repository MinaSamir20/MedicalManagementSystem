using MedicalManagementSystem.Domain.Consts;
using MedicalManagementSystem.Domain.Entities;
using MedicalManagementSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedicalManagementSystem.Infrasturcture.Repositories.BaseRepository
{
    public class BaseRepo<T>(AppDbContext db) : IBaseRepo<T> where T : BaseEntity
    {
        private readonly AppDbContext _db = db;

        public async Task<string> CreateAsync(T entity, string username)
        {
            entity.CreatedBy = username;
            entity.CreatedOn = DateTime.Now;
            await _db.Set<T>().AddAsync(entity);
            return entity.Id.ToString();
        }
        public async Task<IEnumerable<string>> CreateAsync(IEnumerable<T> entities, string username)
        {
            List<string> list = [];
            foreach (var entity in entities)
            {
                entity.CreatedBy = username;
                entity.CreatedOn = DateTime.Now;
                list.Add(entity.Id.ToString());
            }
            await _db.Set<T>().AddRangeAsync(entities);
            return list;
        }

        public async Task<T> GetAsync(int id) => (await GetTableNoTracking().Where(a => a.Id == id).SingleOrDefaultAsync())!;

        public async Task<T> GetAsync(Expression<Func<T, bool>>? criteria, string[]? includes)
        {
            var query = GetTableNoTracking();
            if (includes is not null)
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            if (criteria is not null) query = query.Where(criteria);
            return (await query.SingleOrDefaultAsync())!;
        }
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? criteria, string[]? includes)
        {
            var query = GetTableNoTracking();
            if (includes is not null)
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            if (criteria is not null) query = query.Where(criteria);
            return (await query.ToListAsync())!;
        }

        public async Task<T> FilterAsync(Expression<Func<T, bool>>? search, Expression<Func<T, object>>? orderBy, string OrderByDirection = OrderBy.Ascending)
        {
            var query = GetTableNoTracking();
            if (orderBy is not null)
            {
                if (OrderByDirection == OrderBy.Ascending) query = query.OrderBy(orderBy);
                else query = query.OrderByDescending(orderBy);
            }
            if (search is not null)
                query = query.Where(search);
            return (await query.FirstOrDefaultAsync())!;
        }
        public IQueryable<T> FilterAllAsync(Expression<Func<T, bool>>? search, Expression<Func<T, object>>? orderBy, string OrderByDirection = OrderBy.Ascending)
        {
            var query = GetTableNoTracking();
            if (orderBy is not null)
            {
                if (OrderByDirection == OrderBy.Ascending) query = query.OrderBy(orderBy);
                else query = query.OrderByDescending(orderBy);
            }
            if (search is not null)
                query = query.Where(search);
            return query;
        }

        public IQueryable<T> GetTableNoTracking() => _db.Set<T>().Where(a => a.IsDeleted == false).AsNoTracking().AsQueryable();

        public async Task<string> Update(T entity, string username)
        {
            var t = await _db.Set<T>().FindAsync(entity.Id);
            if (t == null)
            {
                entity.UpdatedOn = DateTime.Now;
                entity.IsUpdated = true;
                entity.UpdatedBy = username;
                _db.Update(entity);
            }
            return "Updated";
        }
        public async Task<string> Update(IEnumerable<T> entities, string username)
        {
            foreach (var entity in entities)
            {
                var t = await _db.Set<T>().FindAsync(entity.Id);
                if (t == null)
                {
                    entity.UpdatedOn = DateTime.Now;
                    entity.IsUpdated = true;
                    entity.UpdatedBy = username;
                    _db.Update(entity);
                }
            }
            return "Updated";
        }

        public async Task<string> DeleteAsync(int id, string username)
        {
            var entity = await _db.Set<T>().FindAsync(id);
            if (entity != null)
            {
                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entity.DeletedBy = username;
            }
            return "Deleted";
        }
        public async Task<string> DeleteAsync(IEnumerable<int> ids, string username)
        {
            foreach (var id in ids)
            {
                var entity = await _db.Set<T>().FindAsync(id);
                if (entity != null)
                {
                    entity.DeletedOn = DateTime.Now;
                    entity.IsDeleted = true;
                    entity.DeletedBy = username;
                }
            }
            return "Deleted";
        }
    }
}

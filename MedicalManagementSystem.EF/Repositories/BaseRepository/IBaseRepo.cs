using MedicalManagementSystem.Domain.Consts;
using System.Linq.Expressions;

namespace MedicalManagementSystem.Infrasturcture.Repositories.BaseRepository
{
    public interface IBaseRepo<T> where T : class
    {
        Task<string> CreateAsync(T entity, string username);
        Task<IEnumerable<string>> CreateAsync(IEnumerable<T> entities, string username);

        Task<T> GetAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>>? criteria, string[]? includes);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? criteria, string[]? includes);

        Task<T> FilterAsync(Expression<Func<T, bool>>? search, Expression<Func<T, object>>? orderBy, string OrderByDirection = OrderBy.Ascending);
        IQueryable<T> FilterAllAsync(Expression<Func<T, bool>>? search, Expression<Func<T, object>>? orderBy, string OrderByDirection = OrderBy.Ascending);

        IQueryable<T> GetTableNoTracking();

        Task<string> Update(T entity, string username);
        Task<string> Update(IEnumerable<T> entities, string username);

        Task<string> DeleteAsync(int id, string username);
        Task<string> DeleteAsync(IEnumerable<int> ids, string username);
    }
}

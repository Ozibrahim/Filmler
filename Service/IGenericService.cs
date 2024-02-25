using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IGenericService<T> where T : class
    {
        Task<T> FirstOrDefault(Expression<Func<T, bool>> expression, string[]? includes = null);
        IQueryable<T> GetList(Expression<Func<T, bool>> expression, string[]? includes = null, Func<T, object>? orderby = null, bool desc = true, bool asNoTracking = true);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);

        //Task<T> GetByIdAsync(int id);
        //Task<T> GetByGuidIdAsync(Guid id);
        //Task<T> SingleAsync(Expression<Func<T, bool>> expression, string[]? includes = null);
        //Task<IEnumerable<T>> GetAllAsync(int? pageNumber = null, int? pageSize = null);
        //Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression, string[]? includes = null, Func<T, object>? orderby = null, bool desc = true, bool asNoTracking = true, int pageSize = int.MaxValue, int pageNumber = 1);
        //Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        //Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        //Task RemoveRangeAsync(IEnumerable<T> entities);
        //Task Truncate();
        //Task GetAllAsync(string[] includes);
    }
}

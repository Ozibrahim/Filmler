using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> FirstOrDefault(Expression<Func<T, bool>> expression, string[] includes = null);
        IQueryable<T> GetList(Expression<Func<T, bool>> expression, string[] includes = null, Func<T, object> orderby = null, bool desc = false, bool asNoTracking = true);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        //IEnumerable<T> GetAll();

        //Task<T> GetByIdAsync(int id);
        //Task<T> GetByGuidIdAsync(Guid id);
        //Task<T> SingleAsync(Expression<Func<T, bool>> expression, string[] includes = null);
        //Task<IEnumerable<T>> GetAllAsync(int? pageNumber = null, int? pageSize = null);
        //Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression, string[] includes = null, Func<T, object> orderby = null, bool desc = false, bool asNoTracking = true, int pageSize = int.MaxValue, int pageNumbe = 1);
        //Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        //Task AddRangeAsync(IEnumerable<T> entities);
        //void RemoveRange(IEnumerable<T> entities);
        //Task Truncate();

    }
}

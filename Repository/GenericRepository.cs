using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly FilmlerContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(FilmlerContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            var sorgu = _dbSet.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                    sorgu = sorgu.Include(include);
            }
            return await _dbSet.FirstOrDefaultAsync(expression);
        }



        public IQueryable<T> GetList(Expression<Func<T, bool>> expression, string[] includes = null, Func<T, object> orderby = null, bool desc = false, bool asNoTracking = true)
        {
            var sorgu = _dbSet.AsNoTracking().AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                    sorgu = sorgu.Include(include);
            }
            if (orderby != null)
            {
                if (desc)
                {
                    sorgu.OrderByDescending(orderby);
                }
                else
                {
                    sorgu.OrderBy(orderby);
                }
            }

            return asNoTracking ? sorgu.Where(expression).AsNoTracking() : sorgu.Where(expression);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }


        //public IEnumerable<T> GetAll()
        //{
        //    var s = _dbSet.AsNoTracking().ToList();
        //    return s;
        //}

        //public async Task AddRangeAsync(IEnumerable<T> entities)
        //{
        //    await _dbSet.AddRangeAsync(entities);
        //}

        //public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        //{
        //    return await _dbSet.AnyAsync(expression);
        //}

        //public async Task<IEnumerable<T>> GetAllAsync(int? pageNumber = null, int? pageSize = null)
        //{
        //    return await _dbSet.AsNoTracking().ToListAsync();
        //}

        //public async Task<T> GetByGuidIdAsync(Guid id)
        //{
        //    return await _dbSet.FindAsync(id);
        //}

        //public async Task<T> GetByIdAsync(int id)
        //{
        //    return await _dbSet.FindAsync(id);
        //}

        //public Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression, string[] includes = null, Func<T, object> orderby = null, bool desc = false, bool asNoTracking = true, int pageSize = int.MaxValue, int pageNumber = 1)
        //{
        //    var sorgu = _dbSet.AsNoTracking().AsQueryable();
        //    if (includes != null)
        //    {
        //        foreach (var include in includes)
        //            sorgu = sorgu.Include(include);
        //    }
        //    if (orderby != null)
        //    {
        //        if (desc)
        //        {
        //            sorgu.OrderByDescending(orderby);
        //        }
        //        else
        //        {
        //            sorgu.OrderBy(orderby);
        //        }
        //    }
        //    return asNoTracking
        //         ? sorgu.Where(expression).AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync() : sorgu.Where(expression).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        //}

        //public void RemoveRange(IEnumerable<T> entities)
        //{
        //    _dbSet.RemoveRange(entities);
        //}

        //public async Task<T> SingleAsync(Expression<Func<T, bool>> expression, string[] includes = null)
        //{
        //    var sorgu = _dbSet.AsQueryable();
        //    if (includes != null)
        //    {
        //        foreach (var include in includes)
        //            sorgu = sorgu.Include(include);
        //    }
        //    return await sorgu.SingleOrDefaultAsync(expression);

        //}

        //public Task Truncate()
        //{
        //    return Task.Run(() =>
        //    {
        //        var tableName = typeof(T).Name;

        //        if (_context.Database.ProviderName.Contains("Postgre"))
        //        {
        //            tableName = System.Text.RegularExpressions.Regex.Replace(tableName, "([A-Z])", " $1").Trim().Replace(' ', '_').ToLower();

        //        }
        //        _context.Database.ExecuteSqlRaw("TRUNCATE TABLE " + tableName + " restart identity");
        //    });
        //}


    }
}

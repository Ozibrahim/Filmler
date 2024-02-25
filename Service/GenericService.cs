using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
        }

        public async Task RemoveAsync(T entity)
        {
            _repository.Remove(entity);
        }


        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> expression, string[]? includes = null)
        {
            return await _repository.FirstOrDefault(expression, includes);
        }


        public IQueryable<T> GetList(Expression<Func<T, bool>> expression, string[]? includes = null, Func<T, object>? orderby = null, bool desc = true, bool asNoTracking = true)
        {
            return _repository.GetList(expression, includes, orderby, desc, asNoTracking);
        }

        //public Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression, string[]? includes = null, Func<T, object>? orderby = null, bool desc = true, bool asNoTracking = true, int pageSize = int.MaxValue, int pageNumber = 1)
        //{
        //    return _repository.GetListAsync(expression, includes, orderby, desc, asNoTracking, pageSize, pageNumber);
        //}

     

        //public async Task RemoveRangeAsync(IEnumerable<T> entities)
        //{
        //    _repository.RemoveRange(entities);
        //}

        //public async Task<T> SingleAsync(Expression<Func<T, bool>> expression, string[]? includes = null)
        //{
        //    var model = await _repository.SingleAsync(expression, includes);
        //    if (model == null)
        //    {
        //        throw new NotImplementedException();
        //    }
        //    return model;
        //}

        //public Task Truncate()
        //{
        //    return _repository.Truncate();
        //}


        //public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        //{
        //    await _repository.AddRangeAsync(entities);
        //    return entities;
        //}

        //public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        //{
        //    return _repository.AnyAsync(expression);
        //}
        //public async Task<IEnumerable<T>> GetAllAsync(int? pageNumber = null, int? pageSize = null)
        //{
        //    return await _repository.GetAllAsync(pageNumber, pageSize);
        //}

        //public Task GetAllAsync(string[] includes)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<T> GetByGuidIdAsync(Guid id)
        //{
        //    var model = await _repository.GetByGuidIdAsync(id);
        //    if (model == null)
        //    {
        //        throw new NotImplementedException();
        //    }
        //    return model;
        //}

        //public async Task<T> GetByIdAsync(int id)
        //{
        //    var model = await _repository.GetByIdAsync(id);
        //    if (model == null)
        //    {
        //        throw new NotImplementedException();
        //    }
        //    return model;
        //}
    }
}

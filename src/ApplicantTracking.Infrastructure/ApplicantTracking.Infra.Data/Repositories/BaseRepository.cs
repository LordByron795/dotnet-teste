using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ApplicantTracking.Domain.Entities;
using ApplicantTracking.Domain.Interfaces;
using ApplicantTracking.Infra.Data.Context;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace ApplicantTracking.Infra.Data.Repositories
{
    public abstract class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationContext _appContext;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _appContext = context;
            _dbSet = _appContext.Set<T>();
        }

        public Task Add(T entity)
        {
            _dbSet.Add(entity);
            return _appContext.SaveChangesAsync();
        }

        public Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            return _appContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll() => await _dbSet.ToListAsync();

        public async Task<T?> GetById(int id) => await _dbSet.FindAsync(id);

        public Task Update(T entity)
        {
            _dbSet.Update(entity);
            return _appContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> where) => await _dbSet.Where(where).ToListAsync();

    }
}

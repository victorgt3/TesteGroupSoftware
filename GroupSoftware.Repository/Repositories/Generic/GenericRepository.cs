using GroupSoftware.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GroupSoftware.Repository.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntityCommonProperty
    {
        public ApplicationDbContext _context;
        private readonly DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
            return entity;
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            return await SaveChangesAsync();
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            var query = dbSet.Select(c => c).Where(where);
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }
        public virtual async Task<List<T>> GetWhwereAllAsync(Expression<Func<T, bool>> where)
        {
            var query = dbSet.Select(c => c).Where(where);
            return await query.ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = dbSet.Select(c => c);
            return await query.ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

       
        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
        #endregion
    }
}

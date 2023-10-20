using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.DataTools
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected DbContext _context;
        protected DbSet<T> _set;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public int Count => _set.Count();

        public async Task CreateAsync(T t)
        {
            await Task.Run(() => { _set.Add(t); });
        }

        public async Task DeleteAsync(T t)
        {
            await Task.Run(() => { _set.Remove(t); });
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _set.Any(expression);
        }

        public async Task<T> FindAsync(object key)
        {
            return await _set.FindAsync(key);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression = null, string includes = null)
        {
            var data = includes != null ? _set.Include(includes) : _set;
            return expression != null ? await data.Where(expression).ToListAsync() : await data.ToListAsync();
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> expression = null, string includes = null)
        {
            var data = includes != null ? _set.Include(includes) : _set;
            return expression != null ? await data.FirstOrDefaultAsync(expression) : await data.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T t)
        {
            _context.Entry(t).State = EntityState.Modified;
            await Task.CompletedTask;
        }
    }
}

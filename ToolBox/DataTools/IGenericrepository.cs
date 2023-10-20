using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ToolBox.DataTools
{
    public interface IGenericRepository<T> where T : class
    {
        Task CreateAsync(T t);
        Task UpdateAsync(T t);
        Task DeleteAsync(T t);
        Task<T> FindAsync(object key);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression = null, string includes = null);

        bool Exists(Expression<Func<T, bool>> expression);
        Task<T> FirstAsync(Expression<Func<T, bool>> expression = null, string includes = null);
        int Count { get; }



    }
}

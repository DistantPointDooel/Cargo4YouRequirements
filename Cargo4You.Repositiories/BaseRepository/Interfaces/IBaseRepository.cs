using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cargo4You.Repositiories
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate);

        Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate);

        Task<T> Create(T entity);

        Task Update(T entity);

        Task Delete(T entity);

    }
}

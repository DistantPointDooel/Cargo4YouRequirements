using Cargo4You.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cargo4You.Repositiories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Returns <see cref="IQueryable{T}"/>
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return context.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// Returns <see cref="T"/> by given predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Returs <see cref="IQueryable{T}"/> by given predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).AsNoTracking();
        }

        /// <summary>
        /// Creates <see cref="T"/> in database
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<T> Create(T entity)
        {
            await context.Set<T>().AddAsync(entity);

            await context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Updates <see cref="T"/> to database
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task Update(T entity)
        {
            context.Set<T>().Update(entity);

            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes <see cref="T"/> in database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Delete(T entity)
        {
            context.Set<T>().Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}

using Snowboard.Domain.Abstract;
using Snowboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Snowboard.Domain.Concrete
{
    public class EFRepositoryBase<T> where T : class
    {
        ISnowboardContext context;
        protected DbSet<T> dbSet;
        public EFRepositoryBase(ISnowboardContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
        }
        public IEnumerable<T> Get()
        {
            return dbSet.AsNoTracking().ToList();
        }
        public IQueryable<T> GetQ()
        {
            return dbSet;
        }
        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public T Find(Guid Id)
        {
            return dbSet.Find(Id);
        }
        public void Add(T item)
        {
            dbSet.Add(item);
            context.SaveChanges();
        }
        public void Update(T item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
        public void Remove(T item)
        {
            context.Entry(item).State = EntityState.Deleted;
            dbSet.Remove(item);
            context.SaveChanges();
        }
        public bool Any(Func<T, bool> predicate)
        {
            return dbSet.Any<T>(predicate);
        }
        public void Dispose()
        {
            context.Dispose(true);
        }
        private IQueryable<TResult> Join<TOuter, TInner, TKey, TResult>(IEnumerable<TInner> inner, Expression<Func<TOuter, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<TOuter, TInner, TResult>> resultSelector)
        {
            return null;// dbSet.Join(inner, outerKeySelector, innerKeySelector, resultSelector);
        }

    }
}

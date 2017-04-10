using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Snowboard.Domain.Abstract
{
    public interface IRepository<T> //: IDisposable
        where T  : class
    {
        void Add(T item);
        T Find(Guid id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> predicate);
        IQueryable<T> GetQ();
        bool Any(Func<T, bool> predicate);
        void Remove(T item);
        void Update(T item);
    }
}

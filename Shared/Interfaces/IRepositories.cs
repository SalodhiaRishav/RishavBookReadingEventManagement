using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IRepositories<T> where T : class
    {
        List<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int Id);
        void AddRange(IEnumerable<T> entityList);
        void DeleteRange(IEnumerable<T> entityList);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Shared.Interfaces;

namespace DAL.Repositories
{
    public class Repository<T> : IRepositories<T> where T : class
    {
        private DBcontext DBcontext;

        public Repository(DBcontext dBcontext)
        {
            DBcontext = dBcontext;
        }
        public List<T> List { get => DBcontext.Set<T>().ToList(); }

        public void Add(T entity)
        {
            DBcontext.Set<T>().Add(entity);
            return;
        }

        public void AddRange(IEnumerable<T> entityList)
        {
            DBcontext.Set<T>().AddRange(entityList);
        }

        public void Delete(T entity)
        {
            DBcontext.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entityList)
        {
            DBcontext.Set<T>().RemoveRange(entityList);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DBcontext.Set<T>().Where(predicate);
        }

        public T FindById(int Id)
        {
            return DBcontext.Set<T>().Find(Id);
        }

        public void Update(T entity)
        {
            DBcontext.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}

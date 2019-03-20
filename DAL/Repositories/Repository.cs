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
        IUnitOfWork UnitOfWork;
        public DbSet<T> DbSet;

        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            DbSet = UnitOfWork.DbContext.Set<T>();
        }
        public List<T> List { get => DbSet.ToList(); }

        public void Add(T entity)
        {
            DbSet.Add(entity);
            return;
        }

        public void AddRange(IEnumerable<T> entityList)
        {
            DbSet.AddRange(entityList);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entityList)
        {
            DbSet.RemoveRange(entityList);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public T FindById(int Id)
        {
            return DbSet.Find(Id);
        }

        public void Update(T entity)
        {
           UnitOfWork.DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}

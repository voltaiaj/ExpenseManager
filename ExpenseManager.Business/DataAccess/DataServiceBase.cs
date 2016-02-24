using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ExpenseManager.Business.DataAccess
{
    public abstract class DataServiceBase<T> where T : class
    {
        protected DataServiceBase(IUnitOfWork unitOfWork, IDbSet<T> dbSet)
        {
            this.Repository = new DbSetRepository<T>(unitOfWork, dbSet);
        }

        protected DbSetRepository<T> Repository { get; private set; }

        protected IQueryable<T> Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            return this.Repository.Find(expression, includes);
        }

        protected int Count(Expression<Func<T, bool>> expression)
        {
            return this.Repository.Count(expression);
        }

        protected T FirstOrDefault(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            return this.Repository.FirstOrDefault(expression, includes);
        }

        protected T SingleOrDefault(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            return this.Repository.SingleOrDefault(expression, includes);
        }

        public T Add(T entity)
        {
            return this.Repository.Add(entity);
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            return this.Repository.AddRange(entities);
        }

        public T Remove(T entity)
        {         
            return this.Repository.Remove(entity);
        }

        public int SaveChanges()
        {
            return this.Repository.SaveChanges();
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return this.Repository.Exists(expression);
        }

    }
}

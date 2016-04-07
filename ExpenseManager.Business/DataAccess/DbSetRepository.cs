using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ExpenseManager.Business.DataAccess
{
    public class DbSetRepository<T> where T : class
    {
        public DbSetRepository(IUnitOfWork unitOfWork, IDbSet<T> dbSet)
        {
            this.UnitOfWork = unitOfWork;
            this.DbSet = dbSet;
        }

        protected IUnitOfWork UnitOfWork { get; set; }
        protected IDbSet<T> DbSet { get; set; }

        public IQueryable<T> All
        {
            get { return this.DbSet.AsQueryable(); }
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            if (includes == null)
            {
                return this.All.Where(expression);
            }

            return includes.Aggregate(this.All.Where(expression), (current, include) => current.Include(include));
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            if (includes == null)
            {
                return this.All.FirstOrDefault(expression);
            }

            return
                includes.Aggregate(this.All.Where(expression), (current, include) => current.Include(include))
                    .FirstOrDefault();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            if (includes == null)
            {
                return this.All.SingleOrDefault(expression);
            }
            return
                includes.Aggregate(this.All.Where(expression), (current, include) => current.Include(include))
                    .SingleOrDefault();
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            return this.DbSet.Count(expression);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return this.DbSet.Any(expression);
        }

        public T Add(T item)
        {
            return this.DbSet.Add(item);
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            for (int index = 0; index < entities.Count(); index++)
            {
                this.DbSet.Add(entities.ElementAt(index));
            }

            return entities;
        }

        public T Remove(T item)
        {
            return this.DbSet.Remove(item);
        }

        public int SaveChanges()
        {
            return this.UnitOfWork.SaveChanges();
        }
    }
}

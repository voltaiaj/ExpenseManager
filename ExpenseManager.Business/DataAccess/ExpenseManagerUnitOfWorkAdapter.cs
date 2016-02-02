using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace ExpenseManager.Business.DataAccess
{
    public class ExpenseManagerUnitOfWorkAdapter : IUnitOfWork, IDisposable
    {
        public ExpenseManagerUnitOfWorkAdapter(IExpenseManagerDbContext context)
        {
            this._Context = context;
        }

        private IExpenseManagerDbContext _Context { get; set; }

        public int SaveChanges()
        {
            try
            {
                var result = this._Context.SaveChanges();
                return result;
            }
            catch (DbEntityValidationException e)
            {
                var errors = new List<string>();
                foreach (var eve in e.EntityValidationErrors)                
                {
                    errors.Add(String.Format(CultureInfo.InvariantCulture, "Entity of type '{0} in state '{1}' has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    errors.AddRange(eve.ValidationErrors.Select(ve => String.Format(CultureInfo.InvariantCulture, "- Property: '{0}', Error: '{1}'", ve.PropertyName, ve.ErrorMessage)));
                }
                foreach (var error in errors)
                {
                    Debug.WriteLine(error);
                }
                throw;
            }
        }

        public void SetModified<T>(T entity) where  T : class
        {
            var dbContext = this._Context as DbContext;
            if (dbContext != null)
            {
                dbContext.Entry(entity).State = EntityState.Modified;
            }
        }

        public bool IsEntityLoaded<T>(T entity) where T : class
        {
            var dbContext = this._Context as DbContext;
            if (dbContext == null)
            {
                return false;
            }
            var context = dbContext;
            return context.Set<T>().Local.Any(e => e == entity);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing != true)
            {
                return;            
            }

            var context = this._Context as IDisposable;
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}

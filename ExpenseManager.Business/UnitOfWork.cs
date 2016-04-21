using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManager.Models;

namespace ExpenseManager.Business
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }

    public class UnitOfWork: IUnitOfWork
    {
        public UnitOfWork(IExpenseManagerDbContext context)
        {
            _context = context;
        }

        public int SaveChanges()
        {            
            return _context.SaveChanges();
        }

        private readonly IExpenseManagerDbContext _context;
    }
}

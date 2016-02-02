using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpenseManager.Business.DataAccess;
using ExpenseManager.Models;

namespace ExpenseManager.Business.Services
{
    public interface IExpenseDataService
    {
        Expense GetExpenseById(int id);
        IEnumerable<Expense> GetExpensesByMonthAndYear(DateTime monthAndYear);
        IEnumerable<Expense> GetExpensesByYear(DateTime year);
        Expense Add(Expense expense);
        Expense Remove(Expense expense);
        int SaveChanges();
        bool Exists(Expression<Func<Expense, bool>> expression);
    }

    public class ExpenseDataService : DataServiceBase<Expense> , IExpenseDataService
    {
        public ExpenseDataService(IExpenseManagerDbContext context)
            :base(new ExpenseManagerUnitOfWorkAdapter(context), context.Expenses)
        {
        }

        private IExpenseManagerDbContext Context { get; set; }

        public Expense GetExpenseById(int id)
        {
            return Context.Expenses.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Expense> GetExpensesByMonthAndYear(DateTime monthAndYear)
        {
            return Context.Expenses.Where(x => x.Date.Month == monthAndYear.Month && x.Date.Year == monthAndYear.Year);
        }

        public IEnumerable<Expense> GetExpensesByYear(DateTime year)
        {
            return Context.Expenses.Where(x => x.Date.Year == year.Year);
        }

    }
}
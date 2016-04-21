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
        IEnumerable<Expense> AddRange(IEnumerable<Expense> expenses);
        Expense Remove(Expense expense);
        int SaveChanges();
        bool Exists(Expression<Func<Expense, bool>> expression);
        IEnumerable<Expense> GetAllExpenses();
    }

    public class ExpenseDataService : DataServiceBase<Expense>, IExpenseDataService
    {
        public ExpenseDataService(IExpenseManagerDbContext context)
            : base(new ExpenseManagerUnitOfWorkAdapter(context), context.Expenses)
        {
            this._Context = context;
        }

        private IExpenseManagerDbContext _Context { get; set; }

        public Expense GetExpenseById(int id)
        {
            return _Context.Expenses.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Expense> GetExpensesByMonthAndYear(DateTime monthAndYear)
        {
            return _Context.Expenses.Where(x => x.Date.Month == monthAndYear.Month && x.Date.Year == monthAndYear.Year);
        }

        public IEnumerable<Expense> GetExpensesByYear(DateTime year)
        {
            return _Context.Expenses.Where(x => x.Date.Year == year.Year);
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return this.Find(x => true);
        }
    }
}
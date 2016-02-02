
using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseManager.Models;

namespace ExpenseManager.Business.Services
{
    public static class ExpenseDataServiceExtensions
    {
        public static IEnumerable<Expense> GetExpensesAboveValueForYear(this ExpenseDataService expenseDataService, double value, DateTime year)
        {
            return expenseDataService.GetExpensesByYear(year).Where(x => x.Value > value);
        }

        public static IEnumerable<Expense> GetExpensesAboveValueForMonthAndYear(
            this ExpenseDataService expenseDataService, double value, DateTime monthAndYear)
        {
            return expenseDataService.GetExpensesByMonthAndYear(monthAndYear).Where(x => x.Value > value);
        }
    }
}

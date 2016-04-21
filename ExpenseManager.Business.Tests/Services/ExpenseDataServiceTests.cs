using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManager.Business.Services;
using ExpenseManager.Models;
using ExpenseManager.Models.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace ExpenseManager.Business.Tests.Services
{
    [TestClass]
    public class ExpenseDataServiceTests
    {
        private IExpenseDataService _expenseDataService { get; set; }
        private IExpenseManagerDbContext _context { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            _context = new FakeExpenseManagerContext();
            _context.Expenses.Add(new Expense { Id = 1, Date = DateTime.Now.Date });
            _expenseDataService = new ExpenseDataService(_context);
        }

        [TestMethod]
        public void GetExpenseById()
        {            
            var actual = _expenseDataService.GetExpenseById(1);
            actual.Id.ShouldEqual(1);
        }

        [TestMethod]
        public void GetExpensesByMonthAndYear()
        {
            var date = DateTime.Now.Date;
            var actual = _expenseDataService.GetExpensesByMonthAndYear(date);
            actual.First().Date.Month.ShouldEqual(date.Month);
            actual.First().Date.Year.ShouldEqual(date.Year);
        }

        [TestMethod]
        public void GetExpensesByYear()
        {
            var date = DateTime.Now.Date;
            var actual = _expenseDataService.GetExpensesByYear(date);
            actual.First().Date.Year.ShouldEqual(date.Year);
        }

        [TestMethod]
        public void GetAllExpenses()
        {
            var actual = _expenseDataService.GetAllExpenses();
            actual.Count().ShouldEqual(1);
        }
    }
}

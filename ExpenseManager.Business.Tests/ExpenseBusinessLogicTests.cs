using System.Collections.Generic;
using ExpenseManager.Business.BusinessLogic;
using ExpenseManager.Business.BusinessLogic.Fakes;
using ExpenseManager.Business.Services;
using ExpenseManager.Business.Services.Fakes;
using ExpenseManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using Should.Core.Exceptions;

namespace ExpenseManager.Business.Tests
{
    [TestClass]
    public class ExpenseBusinessLogicTests
    {
        private IExpenseDataService _expenseDataService { get; set; }
        private ITrainingSetDataService _trainingSetDataService { get; set; }
        private IExpenseBusinessLogic _expenseBusinessLogic { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            _expenseDataService = new StubIExpenseDataService
            {
                AddExpense = (expense) => new Expense { },
                AddRangeIEnumerableOfExpense = (expenses) => new List<Expense> { },
                ExistsExpressionOfFuncOfExpenseBoolean = (ExpressionOfFunc) => true,
                GetExpenseByIdInt32 = (expenseId) => new Expense { },
                SaveChanges = () => 1,
                RemoveExpense = (expense) => new Expense()
            };
            _trainingSetDataService = new StubITrainingSetDataService
            {
                GetAllTrainingSets = () => new List<TrainingSet> { }
            };

            _expenseBusinessLogic = new ExpenseBusinessLogic(_expenseDataService, _trainingSetDataService);
        }

        [TestMethod]
        public void Add()
        {                                    
            _expenseBusinessLogic.Add(new Expense());                     
        }

        [TestMethod]
        public void AddRange()
        {
            _expenseBusinessLogic.AddRange(new List<Expense> {});
        }

        [TestMethod]
        public void Update()
        {
            _expenseBusinessLogic.Update(new Expense());
        }

        [TestMethod]
        public void Remove()
        {
            _expenseBusinessLogic.Remove(1);
        }

        [TestMethod]
        public void DoesExpenseAlreadyExists()
        {
            var actual = _expenseBusinessLogic.DoesExpenseAlreadyExists(new Expense());
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void Classifier()
        {
            var expenses = new List<string[]>
            {
                new string[] {"10/16/2015", "", "$100.00"},
                new string[] {"", "", ""}
            };
            var actual = _expenseBusinessLogic.Classifier(expenses);

            actual.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetExpenseSummaryFromExpenses()
        {
            var expenses = new List<Expense> {new Expense {}};
            var actual = _expenseBusinessLogic.GetExpenseSummaryFromExpenses(expenses);

            actual.ShouldNotBeNull();
        }
    }
}
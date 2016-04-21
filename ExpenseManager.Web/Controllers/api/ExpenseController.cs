using System.Collections.Generic;
using System.Net;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using ExpenseManager.Business;
using ExpenseManager.Business.BusinessLogic;
using ExpenseManager.Business.Services;
using ExpenseManager.Models;
using Newtonsoft.Json;

namespace ExpenseManager.Web.Controllers.api
{
    [System.Web.Http.RoutePrefix("api/Expense")]
    public class ExpenseController : ApiController
    {
        private IExpenseBusinessLogic _expenseBusinessLogic;
        private IExpenseDataService _expenseDataService;

        public ExpenseController()
        {
            _expenseBusinessLogic = new ExpenseBusinessLogic(new ExpenseDataService(new ExpenseManagerDbContext()),
                new TrainingSetDataService(new ExpenseManagerDbContext()));
            _expenseDataService = new ExpenseDataService(new ExpenseManagerDbContext());
        }

        public ExpenseController(IExpenseBusinessLogic expenseBusinessLogic, IExpenseDataService expenseDataService)
        {
            _expenseBusinessLogic = expenseBusinessLogic;
            _expenseDataService = expenseDataService;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetCurrentMonthExpenses")]
        public IEnumerable<Expense> GetCurrentMonthExpenses()
        {
            return this._expenseDataService.GetAllExpenses();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetCurrentMonthSummary")]
        public ExpenseSummaryDTO GetCurrentMonthSummary()
        {
            return this._expenseBusinessLogic.GetExpenseSummaryFromExpenses(this._expenseDataService.GetAllExpenses());
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("UpdateExpense")]
        public ActionResult UpdateExpense(Expense expense)
        {            
            this._expenseBusinessLogic.Update(expense);
            return new HttpStatusCodeResult(HttpStatusCode.OK);            
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Http;
using ExpenseManager.Business;
using ExpenseManager.Business.BusinessLogic;
using ExpenseManager.Business.Services;
using ExpenseManager.Models;
using Microsoft.Ajax.Utilities;

namespace ExpenseManager.Web.Controllers.api
{
    [RoutePrefix("api/Expense")]
    public class ExpenseController : ApiController
    {
        private IExpenseBusinessLogic _expenseBusinessLogic;
        private IExpenseDataService _expenseDataService;

        public ExpenseController()                       
        {
            _expenseBusinessLogic = new ExpenseBusinessLogic(new ExpenseDataService(new ExpenseManagerDbContext()), new TrainingSetDataService(new ExpenseManagerDbContext()));
            _expenseDataService = new ExpenseDataService(new ExpenseManagerDbContext());
        }    

        public ExpenseController(IExpenseBusinessLogic expenseBusinessLogic, IExpenseDataService expenseDataService)
        {
            _expenseBusinessLogic = expenseBusinessLogic;
            _expenseDataService = expenseDataService;
        }

        [HttpGet]
        [Route("GetCurrentMonthExpenses")]
        public IEnumerable<Expense> GetCurrentMonthExpenses()
        {

            return this._expenseDataService.GetAllExpenses();
        }
    }
}
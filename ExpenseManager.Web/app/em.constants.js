﻿(function() {
    'use strict';
    angular.module('em')
        .constant('expenseManagerUrls', {            
            getCurrentMonthExpenses: 'api/Expense/GetCurrentMonthExpenses',
            getCurrentMonthSummary: 'api/Expense/GetCurrentMonthSummary',
            updateExpense: 'api/Expense/UpdateExpense'
        });
})();
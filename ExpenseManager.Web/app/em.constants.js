(function() {
    'use strict';
    angular.module('em')
        .constant('expenseManagerUrls', {
            
            getCurrentMonthExpenses: 'api/Expense/GetCurrentMonthExpenses'
        });
})();
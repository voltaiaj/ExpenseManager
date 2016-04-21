(function() {
    'use strict';
    angular.module('em')
        .factory('expenseManagerDataService', expenseManagerDataService);

    expenseManagerDataService.$inject = ['dataServiceHelper', 'expenseManagerUrls'];

    function expenseManagerDataService(dataServiceHelper, expenseManagerUrls) {
        var service = {
            getCurrentMonthExpenses: getCurrentMonthExpenses,
            getCurrentMonthSummary: getCurrentMonthSummary,
            updateExpense: updateExpense
        };

        return service;

        function getCurrentMonthExpenses() {
            return dataServiceHelper.get(expenseManagerUrls.getCurrentMonthExpenses);            
        }

        function getCurrentMonthSummary() {
            return dataServiceHelper.get(expenseManagerUrls.getCurrentMonthSummary);
        }

        function updateExpense(expense) {
            return dataServiceHelper.postWithParameters(expenseManagerUrls.updateExpense, expense);
        }
    }
    
})();
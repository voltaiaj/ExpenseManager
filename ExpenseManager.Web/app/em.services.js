(function() {
    'use strict';
    angular.module('em')
        .factory('expenseManagerDataService', expenseManagerDataService);

    expenseManagerDataService.$inject = ['dataServiceHelper', 'expenseManagerUrls']

    function expenseManagerDataService(dataServiceHelper, expenseManagerUrls) {
        var service = {
            getCurrentMonthExpenses: getCurrentMonthExpenses
        };

        return service;

        function getCurrentMonthExpenses() {
            return dataServiceHelper.get(expenseManagerUrls.getCurrentMonthExpenses);
            
        }
    }
    
})();
(function() {
    'use strict';
    angular.module('em.expenseSummary')
        .controller('expenseSummaryController', expenseSummaryController);

    expenseSummaryController.$inject = ['$state', 'expenseManagerDataService'];

    function expenseSummaryController($state, expenseManagerDataService) {
        var vm = this;
        vm.title = 'ExpenseSummary';

        activate();

        function activate() {
            var date = new Date();
            expenseManagerDataService.getCurrentMonthExpenses(date).then(callSuccess);
        }

        function callSuccess(response) {
            vm.expenses = response.data;
            console.log(response.data);
        }
    }
})();
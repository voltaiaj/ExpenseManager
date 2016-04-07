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
            //expenseManagerDataService.getCurrentMonthExpenses(date).then(callSuccess);
            //expenseManagerDataService.getCurrentMonthSummary().then(callSuccess);
        }

        function callSuccess(response) {
            vm.expenses = response.data.expenses;
            vm.labels_Categories = response.data.labels_Categories;
            vm.data_Categories = response.data.data_Categories;
            vm.labels_Tiers = response.data.labels_Tiers;
            vm.data_Tiers = response.data.data_Tiers;
            console.log(response.data);
        }
    }
})();
(function() {
    'use strict';
    angular.module('em.expenseSummary')
        .controller('expenseSummaryController', expenseSummaryController);

    expenseSummaryController.$inject = ['$state', 'expenseManagerDataService'];

    function expenseSummaryController($state, expenseManagerDataService) {
        var vm = this;
        vm.title = 'ExpenseSummary';
        vm.expenseToEdit = {};

        vm.editExpense = editExpense;
        vm.updateExpense = updateExpense;

        activate();

        function activate() {
            var date = new Date();
            //expenseManagerDataService.getCurrentMonthExpenses(date).then(callSuccess);
            dataRefresh();
        }

        function callSuccess(response) {
            vm.expenses = response.data.expenses;
            vm.labels_Categories = response.data.labels_Categories;
            vm.data_Categories = response.data.data_Categories;
            vm.labels_Tiers = response.data.labels_Tiers;
            vm.data_Tiers = response.data.data_Tiers;
            vm.categories = response.data.categories;
            console.log(response.data);
        }

        function dataRefresh() {
            expenseManagerDataService.getCurrentMonthSummary().then(callSuccess);
        }

        function editExpense(expense) {
            vm.expenseToEdit = expense;
        }

        function updateExpense(expenseToUpdate) {
            expenseManagerDataService.updateExpense(expenseToUpdate);
            dataRefresh();
        }
    }
})();
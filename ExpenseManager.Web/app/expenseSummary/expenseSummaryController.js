(function() {
    'use strict';
    angular.module('em.expenseSummary')
        .controller('expenseSummaryController', expenseSummaryController);

    expenseSummaryController.$inject = ['$state', 'expenseManagerDataService'];

    function expenseSummaryController($state, expenseManagerDataService) {
        var vm = this;
        vm.title = 'ExpenseSummary';
        vm.expenseToEdit = {};
        vm.categories = [{ Name: 'Gym', Value: 1 }, { Name: 'Mortgage', Value: 2 }, { Name: 'CarInsurance', Value: 3 },
            { Name: 'SatelliteTv', Value: 4 }, { Name: 'CellPhone', Value: 5 }, { Name: 'Internet', Value: 6 },
            { Name: 'Spotify', Value: 7 }, { Name: 'GasForHome', Value: 8}
        ];

        vm.editExpense = editExpense;
        vm.updateExpense = updateExpense;

        activate();

        function activate() {
            var date = new Date();
            expenseManagerDataService.getCurrentMonthExpenses(date).then(callSuccess);
            expenseManagerDataService.getCurrentMonthSummary().then(callSuccess);
        }

        function callSuccess(response) {
            vm.expenses = response.data.expenses;
            vm.labels_Categories = response.data.labels_Categories;
            vm.data_Categories = response.data.data_Categories;
            vm.labels_Tiers = response.data.labels_Tiers;
            vm.data_Tiers = response.data.data_Tiers;
            console.log(response.data);
        }

        function editExpense(expense) {
            vm.expenseToEdit = expense;
        }

        function updateExpense(expenseToUpdate) {
            expenseManagerDataService.updateExpense(expenseToUpdate);
        }
    }
})();
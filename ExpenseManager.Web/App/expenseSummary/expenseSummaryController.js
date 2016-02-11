(function() {
    'use strict';

    angular.module('em.expenseSummary')
        .controller('expenseSummaryController', expenseSummaryController);

    expenseSummaryController.$inject = ['$state'];

    function expenseSummaryController($state) {
        var vm = this;
        vm.title = 'ExpenseSummary';

        vm.items = [1, 2, 3, 4, 5, 6];
        vm.matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];

        vm.class = 'redbox';
    }
})();
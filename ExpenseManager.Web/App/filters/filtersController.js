(function() {
    'use strict';

    angular.module('em.filters')
        .controller('filtersController', filtersController);

    filtersController.$inject = ['$state'];

    function filtersController($state) {
        var vm = this;
        vm.title = 'Filters';

        vm.items = [1, 2, 3, 4, 5, 6];
        vm.matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];

        vm.class = 'redbox';
    }
})();
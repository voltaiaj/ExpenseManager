(function() {
    'use strict';
    angular.module('em.expressions')
        .controller('expressionsController', expressionsController);

    expressionsController.$inject = ['$state'];

    function expressionsController($state) {
        var vm = this;
        vm.title = 'Expressions';
        //vm.helloWorld = 'Hello World'; // used to demonstrate what happens when something is used in an expression but not defined on the scope
        vm.a = 12;
        vm.b = 12;

        vm.x = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
        vm.y = [[11, 12, 13], [14, 15, 16], [17, 18, 19]];

        vm.expressions = [
            {
                view: "{{ 1 + 1 }}",
                isValid: true,
                value: 2
            },
            {
                view: "{{ 12 x 12 }}",
                isValid: true,
                value: 144
            },
            {
                view: "{{ [1,2,3] x 2 }}",
                isValid: false,
                value: [1,2,3]*2
            },
            {
                view: "{{[[1,2,3][1,2,3]]}}",
                isValid: false,
                value: [[1,2,3][1,2,3]]
            }
        ];
    }
})();
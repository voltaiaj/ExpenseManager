(function() {
    'use strict';

    angular.module('em')
        .controller('menuController', menuController);

    menuController.$inject = ['$state', '$rootScope'];

    function menuController($state, $rootScope) {
        var vm = this;

        activate();

        function activate() {
            
        }
    }
})();
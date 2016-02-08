(function () {
    'use strict';
    angular
        .module('em.home')
        .controller('homeIndexController', homeIndexController);

    homeIndexController.$inject = ['$state'];

    function homeIndexController($state) {

        var vm = this;
        vm.title = "Home";

    };
})();
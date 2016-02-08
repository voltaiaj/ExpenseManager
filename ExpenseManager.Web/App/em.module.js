(function() {
    'use strict';

    angular.module('em', [
            'ui.router',
            'em.home'
        ])
        .config([
            '$stateProvider', '$urlRouterProvider', '$locationProvider',
            function($stateProvider, $urlRouteProvider, $locationProvider) {
                $urlRouteProvider.otherwise('/');

                $stateProvider.state('homeIndex', {
                    url: '/',
                    templateUrl: '/App/home/homeIndex.html',
                    controller: 'homeIndexController as vm',
                    data: { pageTitle: 'Home' }
                });

                $locationProvider.html5Mode(false);
            }
        ])
        .run([
            '$rootScope', '$state', '$stateParams',
            function($rootScope, $state, $stateParams) {
                $rootScope.$state = $state;
                $rootScope.$stateParams = $stateParams;
            }
        ]);
})();
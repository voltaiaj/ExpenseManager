(function() {
    'use strict';

    angular.module('em', [
            'ui.router',
            'em.home',
            'em.expenseSummary',
            'em.randomness'
        ])
        .config([
            '$stateProvider', '$urlRouterProvider', '$locationProvider',
            function($stateProvider, $urlRouteProvider, $locationProvider) {
                $urlRouteProvider.otherwise('/');

                $stateProvider.state('homeIndex', {
                    url: '/',
                    templateUrl: '/App/home/homeIndex.html',
                    controller: 'homeIndexController as vm'                    
                });

                $stateProvider.state('expenseSummary', {
                    url: '/expenseSummary',
                    templateUrl: '/App/expenseSummary/expenseSummary.html',
                    controller: 'expenseSummaryController as vm'
                });

                $stateProvider.state('randomness', {
                    url: '/randomness',
                    templateUrl: '/App/randomness/randomness.html',
                    controller: 'randomnessController as vm'
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
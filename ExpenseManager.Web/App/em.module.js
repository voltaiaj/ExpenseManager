(function() {
    'use strict';

    angular.module('em', [            
            'ui.router',
            'em.home',
            'em.filters',
            'em.expressions',
            'em.expenseSummary',
            'utils'
        ])
        .config([
            '$stateProvider', '$urlRouterProvider', '$locationProvider',
            function($stateProvider, $urlRouteProvider, $locationProvider) {
                $urlRouteProvider.otherwise('/');

                $stateProvider.state('homeIndex', {
                    url: '/',
                    templateUrl: '/app/home/homeIndex.html',
                    controller: 'homeIndexController as vm'                    
                });

                $stateProvider.state('expenseSummary', {
                    url: '/expenseSummary',
                    templateUrl: '/app/expenseSummary/expenseSummary.html',
                    controller: 'expenseSummaryController as vm'
                });

                //................................................
                //____________Tech Discussion Learning____________                
                $stateProvider.state('filters', {
                    url: '/filters',
                    templateUrl: '/app/filters/filters.html',
                    controller: 'filtersController as vm'
                });

                $stateProvider.state('expressions', {                    
                    url: '/expressions',
                    templateUrl: '/app/expressions/expressions.html',
                    controller: 'expressionsController as vm'
                });

                $stateProvider.state('expressions.examples', { url: '/examples', templateUrl: '/App/expressions/examples.html' });

                $stateProvider.state('#panel-919247', { url: '#panel-919247' });
                $stateProvider.state('#panel-776251', { url: '#panel-776251' });                
                //________________________________________________
                //................................................

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
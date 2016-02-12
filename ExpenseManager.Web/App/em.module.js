(function() {
    'use strict';

    angular.module('em', [
            'ui.router',
            'em.home',
            'em.filters',
            'em.expressions'
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

                $stateProvider.state('filters', {
                    url: '/filters',
                    templateUrl: '/App/filters/filters.html',
                    controller: 'filtersController as vm'
                });

                $stateProvider.state('expressions', {
                    abstract: false,
                    url: '/expressions',
                    templateUrl: '/App/expressions/expressions.html',
                    controller: 'expressionsController as vm'
                }).state('expressions.examples', {url: '/examples', templateUrl: '/App/expressions/examples.html'});

                $stateProvider.state('#panel-919247', { url: '#panel-919247' });
                $stateProvider.state('#panel-776251', { url: '#panel-776251' });

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
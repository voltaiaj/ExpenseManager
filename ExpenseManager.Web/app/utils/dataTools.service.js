(function() {
    'use strict';

    angular.module('utils')
        .factory('dataToolsService', dataToolsService);

        function dataToolsService() {
            var service = {
                getItemByProperty: getItemByProperty
            };

            function getItemByProperty(array, propName, value) {                
                for (var index in array) {
                    if (array[index][propName] === value) {
                        return array[index];
                    }
                }
                return null;
            }

            return service;
        }
})();
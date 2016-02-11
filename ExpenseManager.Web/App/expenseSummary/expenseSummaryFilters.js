(function() {
    'use strict';
    angular.module('em.expenseSummary')
        .filter('oddFilter', oddFilter)
        .filter('evenFilter', evenFilter);

    function oddFilter() {
        return function(inputArray) {
            var result = [];

            for (var index in inputArray) {
                if (inputArray[index] % 2 != 0) {
                    result.push(inputArray[index]);
                }
            }
            return result;
        }
    }

    function evenFilter() {
        return function (inputArray) {
            var result = [];

            for (var index in inputArray) {
                if (inputArray[index] % 2 == 0) {
                    result.push(inputArray[index]);
                }
            }
            return result;
        }
    }
})();
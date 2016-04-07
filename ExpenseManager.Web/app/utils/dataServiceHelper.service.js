(function () {
    'use strict';

    angular.module('utils')
        .factory('dataServiceHelper', dataServiceHelper);

    dataServiceHelper.$inject = ['urlHelper', '$http'];

    //  This helper service makes writing our data access services MUCH simpler
    //  It forces conventions to be followed, and removes a ton of redudnant boilerplate code from our data services

    function dataServiceHelper (urlHelper, $http) {
        return {
            get: get,
            getWithKey: getWithKey,
            getWithObj: getWithObj,
            getWithQuerystring: getWithQuerystring,
            postWithParameters: postWithParameters,
            postWithoutParameters: postWithoutParameters
        };

        //  need better names for these helper functions maybe??
        function get (url) {
            /// <summary>Issues a GET request (stripping trailing slash)</summary>
            var fullUrl = urlHelper.removeTrailingSlashOnUrl(url);
            return $http.get(fullUrl);            
        }

        function getWithKey (url, key) {
            /// <summary>Issues a GET request by simply appending the key value to the end of the URL after a trailing slash</summary>
            var fullUrl = urlHelper.addTrailingSlashOnUrl(url) + key;
            return $http.get(fullUrl);
        }

        function getWithObj(url, obj) {
            var fullUrl = urlHelper.removeTrailingSlashOnUrl(url);
            return $http({method: 'GET', url:url, data: obj});
        }

        function getWithQuerystring (url, params) {
            /// <summary>Issues a GET request by putting parameter key/values into the querystring</summary>
            return $http.get(urlHelper.removeTrailingSlashOnUrl(url), { params: params });
        }

        function postWithParameters (url, params) {
            /// <summary>Issues a POST request by putting parameter key/values into the request body</summary>
            return $http.post(urlHelper.removeTrailingSlashOnUrl(url), params);
        }

        function postWithoutParameters (url) {
            /// <summary>Issues a POST request but with no parameters (rare)</summary>
            return $http.post(urlHelper.removeTrailingSlashOnUrl(url));
        }
    }
})();
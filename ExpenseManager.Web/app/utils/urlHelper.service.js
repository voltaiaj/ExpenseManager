(function () {
    'use strict';

    angular.module('utils')
        .factory('urlHelper', urlHelper);

    function urlHelper() {
        var service = {
            addTrailingSlashOnUrl: addTrailingSlashOnUrl,
            removeTrailingSlashOnUrl: removeTrailingSlashOnUrl
        };

        function addTrailingSlashOnUrl(url) {
            /// <summary>Add a trailing slash to a URL if it is not there already</summary>
            return url.replace(/\/?$/, '/');
        }

        function removeTrailingSlashOnUrl(url) {
            /// <summary>Remove a trailing slash from a URL</summary>
            return url.replace(/\/+$/, '');
        }

        return service;
    }
})();
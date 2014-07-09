/// <reference path="../../app.js" />
/// <reference path="../../../angular.js" />

(function () {
    'use strict';

    var serviceId = 'jsonValidator';

    // TODO: replace app with your module name
    angular.module('DummyAPI').factory(serviceId, [JsonValidator]);

    function JsonValidator($http) {
        // Define the functions and properties to reveal.
        var service = {
            isValid: isValid
        };

        return service;

        function isValid(body) {
            try {
                jQuery.parseJSON(body);
            } catch (e) {
                return false;
            }
            return true;
        }

        //#region Internal Methods        

        //#endregion
    }
})();
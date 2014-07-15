/// <reference path="~/scripts/angular.js" />
/// <reference path="../app.js" />


(function () {
    'use strict';

    var serviceId = 'webServiceGenerator';

    // TODO: replace app with your module name
    angular.module('DummyAPI').factory(serviceId, ['$http', '$log', WebServiceGenerator]);

    function WebServiceGenerator($http, $log) {
        // Define the functions and properties to reveal.
        var service = {
            getServiceResponse: getServiceResponse,
            createService: createService,
            updateService: updateService
        };

        return service;

        function getServiceResponse(id, successCallback) {
            $http({
                method: 'GET',
                url: '/api/dummy/' + id
            }).success(function (data, status, headers, config) {
                successCallback(data);
            }).
           error(function (data, status, headers, config) {
               $log.warn(data, status, headers, config);
               alert('Error reading ')
           });
        }
        function createService(service, successCallback) {
            $http({
                method: 'POST',
                url: '/api/dummy',
                data: service,
                headers: { 'Content-Type': 'application/json' }

            }).success(function (data, status, headers, config) {
                successCallback(data);
            }).
            error(function (data, status, headers, config) {
                $log.warn(data, status, headers, config);
            });
        }
        function updateService(id, responseData, successCallback) {
            $http({
                method: 'PUT',
                url: '/api/dummy/' + id,
                data: responseData
                //headers: { 'Content-Type': 'application/json' }

            }).success(function (data, status, headers, config) {
                successCallback(data);
            }).
           error(function (data, status, headers, config) {
               $log.warn(data, status, headers, config);
           });
        }

        //#region Internal Methods        

        //#endregion
    }
})();
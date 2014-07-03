/// <reference path="~/scripts/angular.js" />
/// <reference path="../app.js" />

'use strict';


app.factory('webServiceGenerator', function ($http, $log) {
    return {

        getServiceResponse: function (id, successCallback)
        {
            $http({
                method: 'GET',
                url: '/api/dummy/' + id
            }).success(function (data, status, headers, config) {
                successCallback(data);
            }).
           error(function (data, status, headers, config) {
               $log.warn(data, status, headers, config);
           });
        },
        createService: function (responseData, successCallback) {

            $http({
                method: 'POST',
                url: '/api/dummy',
                data: responseData
                //headers: { 'Content-Type': 'application/json' }

            }).success(function (data, status, headers, config) {
                successCallback(data);
            }).
            error(function (data, status, headers, config) {
                $log.warn(data, status, headers, config);
            });
        },
        updateService: function(id, responseData, successCallback)
        {
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
    };
});
/// <reference path="~/scripts/angular.js" />
/// <reference path="../app.js" />

'use strict';


app.factory('webServiceGenerator', function ($http, $log) {
    return {
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
        }
    };
});
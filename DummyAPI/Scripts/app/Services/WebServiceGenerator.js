/// <reference path="~/scripts/angular.js" />
/// <reference path="../app.js" />

'use strict';


app.factory('webServiceGenerator', function ($http, $log) {
    return {
        createService: function (responseData, successCallback) {

            //$http.post('/api/dummy/post', responseData,
            //{
            //    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            //}).
            //    success(function (data, status, headers, config) {
            //        successCallback(data);
            //    }).
            //    error(function (data, status, headers, config) {
            //        $log.warn(data, status, headers, config);
            //    });

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

        generatedService:
            {
                url: 'http//:google2.com'
            }
    };
});
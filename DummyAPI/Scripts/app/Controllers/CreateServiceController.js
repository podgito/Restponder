/// <reference path="~/scripts/angular.js" />
/// <reference path="../app.js" />

'use strict';

app.controller('CreateServiceController',
    function CreateServiceController($scope) {

        $scope.service = {
            responseBody: '',
            url: ''
        },
        $scope.createService = function(service)
        {
            service.url = 'http://google.com';
            console.log(service.responseBody);
            //window.alert(service.responseBody);
        },
        $scope.clearService = function (service)
        {
            service.responseBody = '';
            service.url = '';
        }


    });


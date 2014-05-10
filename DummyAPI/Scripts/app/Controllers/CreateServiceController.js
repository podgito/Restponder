/// <reference path="~/scripts/angular.js" />
/// <reference path="../app.js" />
/// <reference path="../Services/WebServiceGenerator.js" />

'use strict';

app.controller('CreateServiceController',
    function CreateServiceController($scope, webServiceGenerator) {

        $scope.service = {
            responseBody: '',
            url: ''
        },
        $scope.createService = function (service, createServiceForm)
        {
            if (createServiceForm.$valid)
            {
                service.url = webServiceGenerator.generatedService.url;
                console.log(service.responseBody);
            }
           
        },
        $scope.clearService = function (service)
        {
            service.responseBody = '';
            service.url = '';
        }


    });


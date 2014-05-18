/// <reference path="~/scripts/angular.js" />
/// <reference path="../app.js" />
/// <reference path="../Services/WebServiceGenerator.js" />

'use strict';

app.controller('CreateServiceController',
    function CreateServiceController($scope, webServiceGenerator) {

        //$scope.service = {
        //    responseBody: '',
        //    url: ''
        //},
        $scope.response = {
            body: '',
            headers: [],
            url: ''
        },
        $scope.createService = function (response, createServiceForm)
        {
            if (createServiceForm.$valid)
            {
                webServiceGenerator.createService(response.body, function (data) {
                    response.url = data.url;
                });

                //service.url = webServiceGenerator.generatedService.url;
                console.log(response.body);
            }
           
        },
        $scope.clearService = function (response)
        {
            //service.responseBody = '';
            //service.url = '';

            response.body = '';
            response.url = '';

        }


    });


/// <reference path="~/scripts/angular.js" />
/// <reference path="../app.js" />
/// <reference path="../Services/WebServiceGenerator.js" />

'use strict';

app.controller('UpdateServiceController',
    function UpdateServiceController($scope, webServiceGenerator) {

        $scope.init = function(id)
        {
            webServiceGenerator.getServiceResponse(id, function (data) {

                if (typeof data == 'string')
                {
                    $scope.response.body = data;
                }
                else
                {
                    $scope.response.body = JSON.stringify(data);
                }
                
            });
        },
        $scope.response = {
            body: '', //todo set the body 
            headers: [],
            url: ''
        },
        $scope.updateService = function (id, response, createServiceForm) {
            if (createServiceForm.$valid) {
                webServiceGenerator.updateService(id, response.body, function (data) {
                    response.url = data.url;
                });

                //service.url = webServiceGenerator.generatedService.url;
                console.log(response.body);
            }
        },
        $scope.clearService = function (response) {
            //service.responseBody = '';
            //service.url = '';

            response.body = '';
            response.url = '';

        }


    });


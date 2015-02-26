/// <reference path="~/scripts/angular.js" />
/// <reference path="../app.js" />
/// <reference path="../Services/WebServiceGenerator.js" />

'use strict';

app.controller('UpdateServiceController',
    function UpdateServiceController($scope, webServiceGenerator) {

        $scope.init = function(id, url)
        {
            $scope.response.url = url;
            webServiceGenerator.getServiceResponse(id, function (data) {

                if (typeof data == 'string')
                {
                    $scope.response.body = data;
                    $scope.savedResponse.body = data;
                }
                else if (typeof data == 'object')
                {
                    $scope.response.body = JSON.stringify(data, null, 2);
                    $scope.savedResponse.body = JSON.stringify(data, null, 2);
                }
                else {
                    $scope.response.body = String(data);
                    $scope.savedResponse.body = String(data);
                }
                
            });
        },
        $scope.savedResponse = {
            body: '',  
            headers: [],
            url: ''
        },
        $scope.response = {
            body: '',  
            headers: [],
            url: ''
        },
        $scope.updateService = function (id, response, createServiceForm) {
            if (createServiceForm.$valid) {
                webServiceGenerator.updateService(id, response.body, function (data) {
                    
                });

                //service.url = webServiceGenerator.generatedService.url;
                console.log(response.body);
            }
        },
        $scope.undoChanges = function()
        {
            $scope.response.body = $scope.savedResponse.body;
        },
        $scope.clearService = function (response) {
            //service.responseBody = '';
            //service.url = '';

            response.body = '';
            response.url = '';

        }


    });


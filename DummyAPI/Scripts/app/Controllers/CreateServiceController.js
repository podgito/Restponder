/// <reference path="~/scripts/angular.js" />
/// <reference path="../app.js" />
/// <reference path="../Services/WebServiceGenerator.js" />

'use strict';

app.controller('CreateServiceController',
    function CreateServiceController($scope, webServiceGenerator) {

        $scope.response = {
            body: '',
            headers: [],
            url: ''
        },
        $scope.createService = function (response, createServiceForm) {
            if (createServiceForm.$valid) {
                webServiceGenerator.createService(response.body, function (data) {
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

        },

        $scope.showHeader = false,

        $scope.toggleShowHeader = function()
        {
            $scope.showHeader = !$scope.showHeader;
        },

        $scope.headers = [],
         
        $scope.addHeader = function()
        {
            var newHeader = new Object();
            newHeader.name = '';
            newHeader.value = '';
            $scope.headers.push(newHeader);

        }

        $scope.removeHeader = function(header)
        {
            var index = $scope.headers.indexOf(header);
            $scope.headers.splice(index, 1);
        }


    });


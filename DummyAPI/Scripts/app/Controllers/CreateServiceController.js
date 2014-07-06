/// <reference path="~/scripts/angular.js" />
/// <reference path="../app.js" />
/// <reference path="../Services/WebServiceGenerator.js" />

'use strict';

app.controller('CreateServiceController',
    function CreateServiceController($scope, webServiceGenerator) {
        $scope.response = {
            body: '',
            headers: [],
            url: '',
            editUrl: '',
            key: ''
        },
        $scope.createService = function (response, createServiceForm)
        {
            if (createServiceForm.$valid)
            {
                webServiceGenerator.createService(response.body, function (data) {
                    response.url = data.url;
                    response.key = data.key;
                    response.editUrl = data.editUrl;
                });
                console.log(response.body);
            }
           
        },
        $scope.clearService = function (response)
        {
            response.body = '';
            response.url = '';
        }

        $scope.editApi = function (createServiceForm)
        {
            if (createServiceForm.$valid)
            {
                window.location = $scope.response.editUrl;
            }
        }


    });


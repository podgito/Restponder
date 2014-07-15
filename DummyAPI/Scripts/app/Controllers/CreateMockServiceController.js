(function () {
    'use strict';

    var controllerId = 'CreateMockServiceController';

    // TODO: replace app with your module name
    angular.module('DummyAPI').controller(controllerId,
        ['$scope', 'webServiceGenerator', 'mockServiceRepository', CreateMockServiceController]);

    function CreateMockServiceController($scope, webServiceGenerator, mockServiceRepository) {
        $scope.title = 'CreateMockServiceController';
        //$scope.activate = activate;

        $scope.service = {
            body: '',
            headers: [],
            url: '',
            editUrl: '',
            key: '',
            name: ''
        };
        $scope.createService = function (response, createServiceForm) {
            if (createServiceForm.$valid) {
                webServiceGenerator.createService(response, function (data) {
                    response.url = data.url;
                    response.key = data.key;
                    response.editUrl = data.editUrl;
                    response.name = data.name;
                    mockServiceRepository.addService(data);
                });
                console.log(response.body);
            }

        };
        $scope.clearService = function (response) {
            response.body = '';
            response.url = '';
        };

        $scope.editApi = function (createServiceForm) {
            if (createServiceForm.$valid) {
                window.location = $scope.response.editUrl;
            }
        };

        //function activate() { }
    }
})();

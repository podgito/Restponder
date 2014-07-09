(function () {
    'use strict';

    var controllerId = 'CreateMockServiceController';

    // TODO: replace app with your module name
    angular.module('DummyAPI').controller(controllerId,
        ['$scope', 'webServiceGenerator', CreateMockServiceController]);

    function CreateMockServiceController($scope, webServiceGenerator) {
        $scope.title = 'CreateMockServiceController';
        $scope.activate = activate;

        $scope.response = {
            body: '',
            headers: [],
            url: '',
            editUrl: '',
            key: ''
        };
        $scope.createService = function (response, createServiceForm) {
            if (createServiceForm.$valid) {
                webServiceGenerator.createService(response.body, function (data) {
                    response.url = data.url;
                    response.key = data.key;
                    response.editUrl = data.editUrl;
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

        function activate() { }
    }
})();

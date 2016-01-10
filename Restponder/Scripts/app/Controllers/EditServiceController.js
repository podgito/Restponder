(function () {
    'use strict';

    var controllerId = 'EditServiceController';

    // TODO: replace app with your module name
    angular.module('DummyAPI').controller(controllerId,
        ['$scope','mockServiceRepository', EditServiceController]);

    function EditServiceController($scope, mockServiceRepository) {
        $scope.title = 'EditServiceController';
        $scope.activate = activate;


        $scope.services = mockServiceRepository.services;

        $scope.init = function()
        {
            mockServiceRepository.getServices();
        }




        function activate() { }
    }
})();

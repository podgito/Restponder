(function() {
    'use strict';

    // TODO: replace app with your module name
    angular.module('DummyAPI').directive('contentTypeStack', ['contentTypeValidator', ContentTypeStack]);
    
    function ContentTypeStack(contentTypeValidator) {
        // Usage:
        // 
        // Creates:
        // 
        var directive = {
            link: link,
            restrict: 'E',
            templateUrl: '/ViewTemplates/ContentTypeInfoStack.html',
            replace: true,
            scope:
            {
                buttonGroupClass: '='
                //emptyClass: 'btn-success',
                //plainClass: 'btn-default',
                //xmlClass: 'btn-default',
                //jsonClass : 'btn-default'
    },
            controller: function ($scope) {

                //$scope.buttonGroupClass = 'btn-group-vertical';
                $scope.emptyClass = 'btn-success';

                $scope.plainClass = 'btn-default';
                $scope.xmlClass = 'btn-default';
                $scope.jsonClass = 'btn-default';


            }
        };

        function link(scope, element, attrs, controller) {

            //if (attrs.buttonGroupClass) {
            //    scope.buttonGroupClass = attrs.buttonGroupClass;
            //}

            
            attrs.$observe('text', function (newValue, oldValue) {
                if (newValue !== oldValue) {
                    var state = contentTypeValidator.validate(newValue);


                    //Reset all
                    

                    scope.emptyClass = 'btn-default';
                    scope.plainClass = 'btn-default';
                    scope.xmlClass = 'btn-default';
                    scope.jsonClass = 'btn-default';

                    //Set class based on the state
                    if (state.isEmpty) {
                        scope.emptyClass = 'btn-danger';
                    }
                    if (state.isJson) {
                        scope.jsonClass = 'btn-success';
                    }
                    if (state.isXML) {
                        scope.xmlClass = 'btn-success';
                    }
                    if (state.isPlainText) {
                        scope.plainClass = 'btn-warning';
                    }


                }
            });

        }

        return directive;
    }

})();
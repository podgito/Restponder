/// <reference path="../../angular.js" />
/// <reference path="../app.js" />

'use strict';

app.directive('contentTypeInfoStack', function (contentTypeValidator) {
    return {
        restrict: 'E',
        templateUrl: '/ViewTemplates/ContentTypeInfoStack.html',
        replace: true,
        controller: function($scope)
        {
            $scope.emptyClass = 'btn-success';

            $scope.plainClass = 'btn-default';
            $scope.xmlClass = 'btn-default';
            $scope.jsonClass = 'btn-default';


        },
        link: function(scope, element, attrs, controller)
        {
            attrs.$observe('text', function (newValue, oldValue)
            {
                if(newValue !== oldValue)
                {
                    var state = contentTypeValidator.validate(newValue);

                    //scope.plainClass = 'btn-success';

                    //Reset all
                    scope.emptyClass = 'btn-default';
                    scope.plainClass = 'btn-default';
                    scope.xmlClass = 'btn-default';
                    scope.jsonClass = 'btn-default';

                    //Set class based on the state
                    if(state.isEmpty)
                    {
                        scope.emptyClass = 'btn-success';
                    }
                    if(state.isJson)
                    {
                        scope.jsonClass = 'btn-success';
                    }
                    if(state.isXML)
                    {
                        scope.xmlClass = 'btn-success';
                    }
                    if(state.isPlainText)
                    {
                        scope.plainClass = 'btn-success';
                    }
                 


                    //Parser the input string and return the result object
                    //Options are
                    //Empty
                    //Plain text
                    //JSON
                    //XML

                    

                }
            });
        }
    };
});


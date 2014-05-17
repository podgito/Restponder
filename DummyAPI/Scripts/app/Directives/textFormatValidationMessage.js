/// <reference path="../../angular.js" />
/// <reference path="../app.js" />


app.directive('textFormatValidationMessage', function (jsonValidator) {
    return {
        restrict: 'E',
        template: '<span>Message</span>',
        replace: true,
        link: function (scope, elem, attr, controller) {
            //var validators = attr.validators.split(','); //TODO only validate with validators asked for

            var inputState = new Object();

            attr.$observe('text', function (newValue, oldValue) {
                if(newValue!==oldValue)
                {
                    //Check the new value

                    if (newValue !== '' && !jsonValidator.isValid(newValue))
                    {
                            //If it fails all tests then display a message
                            elem.text('Input is not valid JSON');

                    }
                    else { elem.text(''); }

                    

                    

                   
                }
            });

            return inputState;
           
        }
    }; //return
});//directive
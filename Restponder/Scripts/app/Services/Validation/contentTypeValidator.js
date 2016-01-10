/// <reference path="~/scripts/angular.js" />
/// <reference path="../../app.js" />

(function () {
    'use strict';

    var serviceId = 'contentTypeValidator';

    // TODO: replace app with your module name
    angular.module('DummyAPI').factory(serviceId, ['jsonValidator', 'xmlValidator', ContentTypeValidator]);

    function ContentTypeValidator(jsonValidator, xmlValidator) {
        // Define the functions and properties to reveal.
        var service = {
            validate: validate
        };

        return service;

        function validate(body) {
            var inputState = new Object();
            //Check if body is either JSON or XML

            inputState.isEmpty = (body == '');

            inputState.isJson = jsonValidator.isValid(body);

            inputState.isXML = xmlValidator.isValid(body);

            inputState.isPlainText = !(inputState.isEmpty || inputState.isJson || inputState.isXML);

            return inputState;
        }

        //#region Internal Methods        

        //#endregion
    }
})();
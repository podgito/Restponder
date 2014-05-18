/// <reference path="~/scripts/angular.js" />
/// <reference path="../../app.js" />

'use strict';

app.factory('contentTypeValidator', function (jsonValidator, xmlValidator) {
    return {
       validate : function (body) {
            //Return state of the input form
            var inputState = new Object();
            //Check if body is either JSON or XML

            inputState.isEmpty = (body == '');

            inputState.isJson = jsonValidator.isValid(body);

            inputState.isXML = xmlValidator.isValid(body);

            inputState.isPlainText = !(inputState.isEmpty || inputState.isJson || inputState.isXML);

            return inputState;


        }
    };
});
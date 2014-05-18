/// <reference path="~/scripts/angular.js" />
/// <reference path="../../app.js" />

'use strict';

app.factory('contentTypeValidator', function (jsonValidator) {
    return {
       validate : function (body) {
            //Return state of the input form
            var inputState = new Object();
            //Check if body is either JSON or XML

            inputState.isEmpty = (body == '');

            inputState.isJson = jsonValidator.isValid(body);

            inputState.isXML = false;

            inputState.isPlainText = !(inputState.isEmpty || inputState.isJson || inputState.isXML);

            return inputState;


        }
    };
});
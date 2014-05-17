/// <reference path="~/scripts/angular.js" />
/// <reference path="../../app.js" />

app.factory('httpBodyValidator', function (jsonValidator)
{
    return {
        checkInput: function (body) {
            //Return state of the input form
            var inputState = new Object();
            //Check if body is either JSON or XML

            inputState.isJson = jsonValidator.isValid(body);

            inputState.isXML = false;

            return inputState;
           
            
        }
    };
});

